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

        public SpanEnumerator<TSource1, TOut, Convert3Operator<TSource1, TSource2, TSource3, TOut, TOperator>> ConvertToEnumerator()
        {
            return new(Source1, new(Operator, Source2, Source3));
        }
    }


    public struct Convert3Operator<TSource1, TSource2, TSource3, TOut, TOperator3> : ISpanOperator<TSource1, TOut>, IDisposable
        where TOperator3 : ISpanOperator3<TSource1, TSource2, TSource3, TOut>
    {
        internal TOperator3 Operator;

        internal TSource2[]? Source2;
        internal int Source2Length;
        internal int Source2Index;
        internal TSource3[]? Source3;
        internal int Source3Length;
        internal int Source3Index;

        internal Convert3Operator(TOperator3 op3, ReadOnlySpan<TSource2> source2, ReadOnlySpan<TSource3> source3)
        {
            Operator = op3;

            Source2 = ArrayPool<TSource2>.Shared.Rent(source2.Length);
            source2.CopyTo(Source2);
            Source2Length = source2.Length;
            Source2Index = 0;

            Source3 = ArrayPool<TSource3>.Shared.Rent(source3.Length);
            source3.CopyTo(Source3);
            Source3Length = source3.Length;
            Source3Index = 0;
        }

        public void Dispose()
        {
            if (Source2 != null)
            {
                ArrayPool<TSource2>.Shared.Return(Source2);
                Source2 = null;
            }
            if (Source3 != null)
            {
                ArrayPool<TSource3>.Shared.Return(Source3);
                Source3 = null;
            }
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSource1> source, out int length)
        {
            return Operator.TryGetNonEnumeratedCount(source, Source2.AsSpan(Source2Index..Source2Length), Source3.AsSpan(Source3Index..Source3Length), out length);
        }

        public TOut TryMoveNext(ref ReadOnlySpan<TSource1> source, out bool success)
        {
            if (Source2 == null || Source3 == null)
            {
                success = false;
                return default!;
            }

            ReadOnlySpan<TSource2> source2 = Source2.AsSpan(Source2Index..Source2Length);
            ReadOnlySpan<TSource3> source3 = Source3.AsSpan(Source3Index..Source3Length);

            var current = Operator.TryMoveNext(ref source, ref source2, ref source3, out success);
            if (!success)
            {
                Dispose();
            }

            if (!Source2.AsSpan().Overlaps(source2, out Source2Index))
            {
                Source2Index = Source2Length;
            }
            if (!Source3.AsSpan().Overlaps(source3, out Source3Index))
            {
                Source3Index = Source3Length;
            }

            return current;
        }
    }
}
