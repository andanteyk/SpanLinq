using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, TakeLastOperator<T, T, IdentityOperator<T>>> TakeLast<T>(this ReadOnlySpan<T> span, int takeCount)
        {
            return new(span, new(new(), takeCount));
        }

        public static SpanEnumerator<T, T, TakeLastOperator<T, T, IdentityOperator<T>>> TakeLast<T>(this Span<T> span, int takeCount)
        {
            return new(span, new(new(), takeCount));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, TakeLastOperator<TSource, TOut, TOperator>> TakeLast(int takeCount)
        {
            return new(Source, new(Operator, takeCount));
        }
    }

    public struct TakeLastOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal int TakeCount;

        internal TIn[]? SourceArray;
        internal int SourceLength;
        internal int Index;

        internal TakeLastOperator(TOperator op, int takeCount)
        {
            Operator = op;
            TakeCount = Math.Max(takeCount, 0);

            SourceArray = null;
            SourceLength = -1;
            Index = -1;
        }

        public void Dispose()
        {
            if (SourceArray != null)
            {
                ArrayPool<TIn>.Shared.Return(SourceArray);
                SourceArray = null;
                Index = int.MinValue;
            }
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            if (Operator.TryGetNonEnumeratedCount(source, out length))
            {
                length = Math.Min(length, Math.Max(TakeCount, 0));
                return true;
            }
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {

            if (Index == -1)
            {
                if (Operator is IdentityOperator<TIn>)
                {
                    SourceLength = Math.Min(TakeCount, source.Length);
                    source = source[(source.Length - SourceLength)..];
                    Index = 0;
                }
                else
                {
                    var sourceSpan = SpanEnumerator<TSpan, TIn, TOperator>.ToArrayPool(source, Operator, out SourceArray);
                    SourceLength = sourceSpan.Length;
                    Index = Math.Max(SourceLength - Math.Max(TakeCount, 0), 0);
                }
            }

            if (Index < SourceLength)
            {
                if (Operator is IdentityOperator<TIn>)
                {
                    return Operator.TryMoveNext(ref source, out success);
                }
                else
                {
                    success = true;
                    return SourceArray![Index++];
                }
            }
            else
            {
                Dispose();
            }

            success = false;
            return default!;
        }
    }
}
