namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T Last<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Last();
        }

        public static T Last<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Last(predicate);
        }

        public static T Last<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Last();
        }

        public static T Last<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Last(predicate);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public TOut Last()
        {
            return Last(x => true);
        }

        public TOut Last(Predicate<TOut> predicate)
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
                    throw new InvalidOperationException();
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
