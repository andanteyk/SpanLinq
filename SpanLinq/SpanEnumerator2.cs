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

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator2<TSource, TSource2, TOut, ConcatOperator2<TSource, TSource2, TOut, TOperator, TOperator2>> Concat2<TSource2, TOperator2>(SpanEnumerator<TSource2, TOut, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TOut>
        {
            return new(Source, second.Source, new(Operator, second.Operator));
        }

        public SpanEnumerator2<TSource, TOut, TOut, ConcatOperator2<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>>> Concat2(ReadOnlySpan<TOut> second)
        {
            return new(Source, second, new(Operator, new IdentityOperator<TOut>()));
        }
    }

    public struct ConcatOperator2<TSpan1, TSpan2, TIn, TOperator1, TOperator2> : ISpanOperator2<TSpan1, TSpan2, TIn>
        where TOperator1 : ISpanOperator<TSpan1, TIn>
        where TOperator2 : ISpanOperator<TSpan2, TIn>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;

        internal ConcatOperator2(TOperator1 operator1, TOperator2 operator2)
        {
            Operator1 = operator1;
            Operator2 = operator2;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan1> source1, ReadOnlySpan<TSpan2> source2, out int length)
        {
            if (Operator1.TryGetNonEnumeratedCount(source1, out int length1) && Operator2.TryGetNonEnumeratedCount(source2, out int length2))
            {
                length = length1 + length2;
                return true;
            }
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan1> source1, ref ReadOnlySpan<TSpan2> source2, out bool success)
        {
            var current1 = Operator1.TryMoveNext(ref source1, out bool ok);
            if (ok)
            {
                success = true;
                return current1;
            }

            var current2 = Operator2.TryMoveNext(ref source2, out ok);
            if (ok)
            {
                success = true;
                return current2;
            }

            success = false;
            return default!;
        }
    }
}
