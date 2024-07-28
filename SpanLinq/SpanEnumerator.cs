using System.Buffers;

namespace SpanLinq
{
    public ref partial struct SpanEnumerator<TSource, TOut, TOperator>
        where TOperator : ISpanOperator<TSource, TOut>
    {
        internal ReadOnlySpan<TSource> Source;
        internal TOperator Operator;

        internal SpanEnumerator(ReadOnlySpan<TSource> source, TOperator op)
        {
            Source = source;
            Operator = op;
        }

        public void CopyTo(Span<TOut> span)
        {
            int i = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool success);
                if (!success)
                {
                    break;
                }

                span[i++] = current;
            }
        }


        internal static Span<TOut> ToArrayPool(ReadOnlySpan<TSource> source, TOperator op, out TOut[] poolingArray)
        {
            int i = 0;
            var temp = ArrayPool<TOut>.Shared.Rent(Math.Max(source.Length, 8));

            while (true)
            {
                var current = op.TryMoveNext(ref source, out bool success);
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
            return ToArrayPool(Source, Operator, out poolingArray);
        }


        public TOut Yield(out bool success)
        {
            return Operator.TryMoveNext(ref Source, out success);
        }


        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public ref struct Enumerator
        {
            SpanEnumerator<TSource, TOut, TOperator> Source;

            internal Enumerator(SpanEnumerator<TSource, TOut, TOperator> source)
            {
                Source = source;
                Current = default!;
            }

            public TOut Current { get; private set; }

            public bool MoveNext()
            {
                Current = Source.Operator.TryMoveNext(ref Source.Source, out bool ok);
                return ok;
            }
        }

    }
}
