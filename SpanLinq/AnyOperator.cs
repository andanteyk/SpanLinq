namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static bool Any<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Any();
        }

        public static bool Any<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Any(predicate);
        }

        public static bool Any<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Any();
        }

        public static bool Any<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Any(predicate);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public bool Any()
        {
            Operator.TryMoveNext(ref Source, out bool ok);
            return ok;
        }

        public bool Any(Predicate<TOut> predicate)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }

                if (predicate(current))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
