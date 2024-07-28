namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T? LastOrDefault<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LastOrDefault();
        }

        public static T? LastOrDefault<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LastOrDefault(predicate);
        }

        public static T LastOrDefault<T>(this ReadOnlySpan<T> span, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LastOrDefault(defaultValue);
        }

        public static T LastOrDefault<T>(this ReadOnlySpan<T> span, Predicate<T> predicate, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LastOrDefault(predicate, defaultValue);
        }


        public static T? LastOrDefault<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LastOrDefault();
        }

        public static T? LastOrDefault<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LastOrDefault(predicate);
        }

        public static T LastOrDefault<T>(this Span<T> span, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LastOrDefault(defaultValue);
        }

        public static T LastOrDefault<T>(this Span<T> span, Predicate<T> predicate, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).LastOrDefault(predicate, defaultValue);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public TOut? LastOrDefault()
        {
            return LastOrDefault(x => true);
        }

        public TOut? LastOrDefault(Predicate<TOut> predicate)
        {
            bool found = false;
            TOut foundObject = default!;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (found)
                    {
                        return foundObject;
                    }
                    return default!;
                }

                if (predicate(current))
                {
                    found = true;
                    foundObject = current;
                }
            }
        }


        public TOut LastOrDefault(TOut defaultValue)
        {
            return LastOrDefault(x => true, defaultValue);
        }

        public TOut LastOrDefault(Predicate<TOut> predicate, TOut defaultValue)
        {
            bool found = false;
            TOut foundObject = default!;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (found)
                    {
                        return foundObject;
                    }
                    return defaultValue;
                }

                if (predicate(current))
                {
                    found = true;
                    foundObject = current;
                }
            }
        }
    }
}
