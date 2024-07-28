using System.Buffers;

namespace SpanLinq
{
    public ref partial struct SpanEnumerator3<TSource1, TSource2, TSource3, TOut, TOperator>
        where TOperator : ISpanOperator3<TSource1, TSource2, TSource3, TOut>
    {
        internal ReadOnlySpan<TSource1> Source1;
        internal ReadOnlySpan<TSource2> Source2;
        internal ReadOnlySpan<TSource3> Source3;
        internal TOperator Operator;

        internal SpanEnumerator3(ReadOnlySpan<TSource1> source1, ReadOnlySpan<TSource2> source2, ReadOnlySpan<TSource3> source3, TOperator op)
        {
            Source1 = source1;
            Source2 = source2;
            Source3 = source3;
            Operator = op;
        }

        internal static Span<TOut> ToArrayPool(ReadOnlySpan<TSource1> source1, ReadOnlySpan<TSource2> source2, ReadOnlySpan<TSource3> source3, TOperator op, out TOut[] poolingArray)
        {
            int i = 0;
            var temp = ArrayPool<TOut>.Shared.Rent(Math.Max(source1.Length + source2.Length, 8));

            while (true)
            {
                var current = op.TryMoveNext(ref source1, ref source2, ref source3, out bool success);
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
            return ToArrayPool(Source1, Source2, Source3, Operator, out poolingArray);
        }

        public SpanIterator<TOut> AsSpan()
        {
            return this;
        }

        public static implicit operator SpanIterator<TOut>(SpanEnumerator3<TSource1, TSource2, TSource3, TOut, TOperator> enumerator3)
        {
            var span = enumerator3.ToArrayPool(out var poolingArray);
            return new SpanIterator<TOut>(poolingArray, span.Length);
        }
    }

    public interface ISpanOperator3<TIn1, TIn2, TIn3, TOut>
    {
        TOut TryMoveNext(ref ReadOnlySpan<TIn1> source1, ref ReadOnlySpan<TIn2> source2, ref ReadOnlySpan<TIn3> source3, out bool success);
        bool TryGetNonEnumeratedCount(ReadOnlySpan<TIn1> source1, ReadOnlySpan<TIn2> source2, ReadOnlySpan<TIn3> source3, out int length);
    }
}
