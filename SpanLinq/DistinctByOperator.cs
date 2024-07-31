namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, DistinctByOperator<T, T, IdentityOperator<T>, TKey, EqualityComparer<TKey>>> DistinctBy<T, TKey>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector)
        {
            return new(span, new(new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, DistinctByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> DistinctBy<T, TKey, TComparer>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, comparer));
        }

        public static SpanEnumerator<T, T, DistinctByOperator<T, T, IdentityOperator<T>, TKey, EqualityComparer<TKey>>> DistinctBy<T, TKey>(this Span<T> span, Func<T, TKey> keySelector)
        {
            return new(span, new(new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, DistinctByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> DistinctBy<T, TKey, TComparer>(this Span<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, DistinctByOperator<TSource, TOut, TOperator, TKey, EqualityComparer<TKey>>> DistinctBy<TKey>(Func<TOut, TKey> keySelector)
        {
            return new(Source, new(Operator, keySelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, TOut, DistinctByOperator<TSource, TOut, TOperator, TKey, TComparer>> DistinctBy<TKey, TComparer>(Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, comparer));
        }
    }

    public struct DistinctByOperator<TSpan, TIn, TOperator, TKey, TComparer> : ISpanOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator Operator;
        internal readonly Func<TIn, TKey> KeySelector;
        internal readonly TComparer Comparer;

        internal ArrayPoolDictionary<TKey, TIn>? Dictionary;

        internal DistinctByOperator(TOperator op, Func<TIn, TKey> keySelector, TComparer comparer)
        {
            Operator = op;
            KeySelector = keySelector;
            Comparer = comparer;
            Dictionary = null;
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
                    Dispose();
                    success = false;
                    return default!;
                }

                if (Dictionary == null)
                {
                    Dictionary = ObjectPool.SharedRent<ArrayPoolDictionary<TKey, TIn>>();
                    Dictionary.ClearAndSetComparer(Comparer);
                }

                var key = KeySelector(current);
                if (Dictionary.TryAdd(key, current))
                {
                    success = true;
                    return current;
                }
            }
        }

        public void Dispose()
        {
            if (Dictionary != null)
            {
                ObjectPool.SharedReturn(Dictionary);
                Dictionary = null!;
            }
        }
    }
}
