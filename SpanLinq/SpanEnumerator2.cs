using System.Buffers;

namespace SpanLinq
{
    public ref partial struct SpanEnumerator2<TSource1, TSource2, TOut, TOperator>
        where TOperator : ISpanOperator2<TSource1, TSource2, TOut>
    {
        internal ReadOnlySpan<TSource1> Source1;
        internal ReadOnlySpan<TSource2> Source2;
        internal TOperator Operator;

        internal SpanEnumerator2(ReadOnlySpan<TSource1> source1, ReadOnlySpan<TSource2> source2, TOperator op)
        {
            Source1 = source1;
            Source2 = source2;
            Operator = op;
        }

        internal static Span<TOut> ToArrayPool(ReadOnlySpan<TSource1> source1, ReadOnlySpan<TSource2> source2, TOperator op, out TOut[] poolingArray)
        {
            int i = 0;
            var temp = ArrayPool<TOut>.Shared.Rent(Math.Max(source1.Length + source2.Length, 8));

            while (true)
            {
                var current = op.TryMoveNext(ref source1, ref source2, out bool success);
                if (!success)
                {
                    break;
                }

                temp[i++] = current;

                if (i >= temp.Length)
                {
                    var newTemp = ArrayPool<TOut>.Shared.Rent(temp.Length << 1);
                    temp.CopyTo(newTemp, 0);
                    ArrayPool<TOut>.Shared.Return(temp);
                    temp = newTemp;
                }
            }

            poolingArray = temp;
            return temp.AsSpan(..i);
        }

        public Span<TOut> ToArrayPool(out TOut[] poolingArray)
        {
            return ToArrayPool(Source1, Source2, Operator, out poolingArray);
        }

        public SpanIterator<TOut> AsSpan()
        {
            return this;
        }

        public static implicit operator SpanIterator<TOut>(SpanEnumerator2<TSource1, TSource2, TOut, TOperator> enumerator2)
        {
            var span = enumerator2.ToArrayPool(out var poolingArray);
            return new SpanIterator<TOut>(poolingArray, span.Length);
        }
    }

    public interface ISpanOperator2<TIn1, TIn2, TOut>
    {
        TOut TryMoveNext(ref ReadOnlySpan<TIn1> source1, ref ReadOnlySpan<TIn2> source2, out bool success);
        bool TryGetNonEnumeratedCount(ReadOnlySpan<TIn1> source1, ReadOnlySpan<TIn2> source2, out int length);
    }
}
