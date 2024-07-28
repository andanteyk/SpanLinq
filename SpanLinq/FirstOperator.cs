namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T First<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).First();
        }

        public static T First<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).First(predicate);
        }

        public static T First<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).First();
        }

        public static T First<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).First(predicate);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public TOut First()
        {
            return First(x => true);
        }

        public TOut First(Predicate<TOut> predicate)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    throw new InvalidOperationException();
                }
                if (predicate(current))
                {
                    return current;
                }
            }
        }
    }
}
