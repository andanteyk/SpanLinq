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

        public SpanEnumerator<TSource1, TOut, Convert2Operator<TSource1, TSource2, TOut, TOperator>> ConvertToEnumerator()
        {
            return new(Source1, new(Operator, Source2));
        }
    }


    public struct Convert2Operator<TSource1, TSource2, TOut, TOperator2> : ISpanOperator<TSource1, TOut>, IDisposable
        where TOperator2 : ISpanOperator2<TSource1, TSource2, TOut>
    {
        internal TOperator2 Operator;

        internal TSource2[]? Source2;
        internal int Source2Length;
        internal int Source2Index;

        internal Convert2Operator(TOperator2 op2, ReadOnlySpan<TSource2> source2)
        {
            Operator = op2;

            Source2 = ArrayPool<TSource2>.Shared.Rent(source2.Length);
            source2.CopyTo(Source2);
            Source2Length = source2.Length;
            Source2Index = 0;
        }

        public void Dispose()
        {
            if (Source2 != null)
            {
                ArrayPool<TSource2>.Shared.Return(Source2);
                Source2 = null;
            }
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSource1> source, out int length)
        {
            return Operator.TryGetNonEnumeratedCount(source, Source2.AsSpan(Source2Index..Source2Length), out length);
        }

        public TOut TryMoveNext(ref ReadOnlySpan<TSource1> source, out bool success)
        {
            if (Source2 == null)
            {
                success = false;
                return default!;
            }

            ReadOnlySpan<TSource2> source2 = Source2.AsSpan(Source2Index..Source2Length);

            var current = Operator.TryMoveNext(ref source, ref source2, out success);
            if (!success)
            {
                Dispose();
            }

            if (!Source2.AsSpan().Overlaps(source2, out Source2Index))
            {
                Source2Index = Source2Length;
            }

            return current;
        }
    }
}
