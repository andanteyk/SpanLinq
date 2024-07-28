namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static bool All<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).All(predicate);
        }

        public static bool All<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).All(predicate);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public bool All(Predicate<TOut> predicate)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }

                if (!predicate(current))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
