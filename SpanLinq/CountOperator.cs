namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static int Count<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Count();
        }

        public static int Count<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Count();
        }

        public static int Count<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Count(predicate);
        }

        public static int Count<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Count(predicate);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public int Count()
        {
            if (Operator.TryGetNonEnumeratedCount(Source, out int length))
            {
                return length;
            }

            return Count(x => true);
        }

        public int Count(Predicate<TOut> predicate)
        {
            int count = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);

                if (!ok)
                {
                    break;
                }

                if (predicate(current))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
