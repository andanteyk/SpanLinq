namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, WhereOperator<T, T, IdentityOperator<T>>> Where<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new(span, new(new(), predicate));
        }

        public static SpanEnumerator<T, T, WhereOperator<T, T, IdentityOperator<T>>> Where<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new(span, new(new(), predicate));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, WhereOperator<TSource, TOut, TOperator>> Where(Predicate<TOut> predicate)
        {
            return new(Source, new(Operator, predicate));
        }
    }

    public struct WhereOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal readonly Predicate<TIn> Predicate;

        internal WhereOperator(TOperator op, Predicate<TIn> predicate)
        {
            Operator = op;
            Predicate = predicate;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref source, out bool ok);
                if (!ok)
                {
                    success = false;
                    return default!;
                }
                if (Predicate(current))
                {
                    success = true;
                    return current;
                }
            }
        }
    }
}
