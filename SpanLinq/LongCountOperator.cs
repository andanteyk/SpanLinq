namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static long LongCount<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LongCount();
        }

        public static long LongCount<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LongCount();
        }

        public static long LongCount<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LongCount(predicate);
        }

        public static long LongCount<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LongCount(predicate);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public long LongCount()
        {
            if (Operator.TryGetNonEnumeratedCount(Source, out int length))
            {
                return length;
            }

            return LongCount(static x => true);
        }

        public long LongCount(Predicate<TOut> predicate)
        {
            long count = 0;
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
