namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, TakeOperator<T, T, IdentityOperator<T>>> Take<T>(this ReadOnlySpan<T> span, int takeCount)
        {
            return new(span, new(new(), takeCount));
        }

        public static SpanEnumerator<T, T, TakeOperator<T, T, IdentityOperator<T>>> Take<T>(this Span<T> span, int takeCount)
        {
            return new(span, new(new(), takeCount));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, TakeOperator<TSource, TOut, TOperator>> Take(int takeCount)
        {
            return new(Source, new(Operator, takeCount));
        }
    }

    public struct TakeOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal int TakeCount;

        internal TakeOperator(TOperator op, int takeCount)
        {
            Operator = op;
            TakeCount = takeCount;
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
            if (TakeCount > 0)
            {
                TakeCount--;
                return Operator.TryMoveNext(ref source, out success);
            }

            success = false;
            return default!;
        }
    }
}
