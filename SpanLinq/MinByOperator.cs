namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T MinBy<T, TKey>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).MaxBy(keySelector);
        }

        public static T MinBy<T, TKey, TComparer>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IComparer<TKey>
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).MaxBy(keySelector, comparer);
        }

        public static T MinBy<T, TKey>(this Span<T> span, Func<T, TKey> keySelector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).MaxBy(keySelector);
        }

        public static T MinBy<T, TKey, TComparer>(this Span<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IComparer<TKey>
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).MaxBy(keySelector, comparer);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public TOut MinBy<TKey>(Func<TOut, TKey> keySelector)
        {
            return MinBy(keySelector, Comparer<TKey>.Default);
        }

        public TOut MinBy<TKey, TComparer>(Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IComparer<TKey>
        {
            int count = 0;
            TOut maxObject = default!;
            TKey maxKey = default!;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }

                    return maxObject;
                }

                if (count == 0)
                {
                    maxObject = current;
                    maxKey = keySelector(current);
                    count++;
                }
                else
                {
                    var currentKey = keySelector(current);
                    if (comparer.Compare(currentKey, maxKey) < 0)
                    {
                        maxObject = current;
                        maxKey = currentKey;
                        count++;
                    }
                }
            }
        }
    }
}
