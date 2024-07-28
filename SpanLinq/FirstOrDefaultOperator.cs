namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T? FirstOrDefault<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).FirstOrDefault();
        }

        public static T? FirstOrDefault<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).FirstOrDefault(predicate);
        }

        public static T FirstOrDefault<T>(this ReadOnlySpan<T> span, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).FirstOrDefault(defaultValue);
        }

        public static T FirstOrDefault<T>(this ReadOnlySpan<T> span, Predicate<T> predicate, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).FirstOrDefault(predicate, defaultValue);
        }

        public static T? FirstOrDefault<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).FirstOrDefault();
        }

        public static T? FirstOrDefault<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).FirstOrDefault(predicate);
        }

        public static T FirstOrDefault<T>(this Span<T> span, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).FirstOrDefault(defaultValue);
        }

        public static T FirstOrDefault<T>(this Span<T> span, Predicate<T> predicate, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).FirstOrDefault(predicate, defaultValue);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public TOut? FirstOrDefault()
        {
            return FirstOrDefault(x => true);
        }

        public TOut? FirstOrDefault(Predicate<TOut> predicate)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    return default;
                }
                if (predicate(current))
                {
                    return current;
                }
            }
        }

        public TOut FirstOrDefault(TOut defaultValue)
        {
            return FirstOrDefault(x => true, defaultValue);
        }

        public TOut FirstOrDefault(Predicate<TOut> predicate, TOut defaultValue)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    return defaultValue;
                }
                if (predicate(current))
                {
                    return current;
                }
            }
        }
    }
}
