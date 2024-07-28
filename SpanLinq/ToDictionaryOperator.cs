using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this ReadOnlySpan<(TKey key, TValue value)> span)
            where TKey : notnull
        {
            return ToDictionary(span, EqualityComparer<TKey>.Default);
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue, TComparer>(this ReadOnlySpan<(TKey key, TValue value)> span, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
            where TKey : notnull
        {
            var dic = new Dictionary<TKey, TValue>(span.Length, comparer);
            foreach (var pair in span)
            {
                dic.Add(pair.key, pair.value);
            }
            return dic;
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this ReadOnlySpan<KeyValuePair<TKey, TValue>> span)
            where TKey : notnull
        {
            return ToDictionary(span, EqualityComparer<TKey>.Default);
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue, TComparer>(this ReadOnlySpan<KeyValuePair<TKey, TValue>> span, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
            where TKey : notnull
        {
            var dic = new Dictionary<TKey, TValue>(span.Length, comparer);
            foreach (var pair in span)
            {
                dic.Add(pair.Key, pair.Value);
            }
            return dic;
        }


        public static Dictionary<TKey, T> ToDictionary<T, TKey>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector)
            where TKey : notnull
        {
            return ToDictionary(span, keySelector, i => i, EqualityComparer<TKey>.Default);
        }

        public static Dictionary<TKey, T> ToDictionary<T, TKey, TComparer>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
            where TKey : notnull
        {
            return ToDictionary(span, keySelector, i => i, comparer);
        }

        public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)
            where TKey : notnull
        {
            return ToDictionary(span, keySelector, valueSelector, EqualityComparer<TKey>.Default);
        }

        public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue, TComparer>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, Func<T, TValue> valueSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
            where TKey : notnull
        {
            var dic = new Dictionary<TKey, TValue>(span.Length, comparer);
            foreach (var element in span)
            {
                dic.Add(keySelector(element), valueSelector(element));
            }
            return dic;
        }





        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Span<(TKey key, TValue value)> span)
            where TKey : notnull
        {
            return ToDictionary(span, EqualityComparer<TKey>.Default);
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue, TComparer>(this Span<(TKey key, TValue value)> span, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
            where TKey : notnull
        {
            var dic = new Dictionary<TKey, TValue>(span.Length, comparer);
            foreach (var pair in span)
            {
                dic.Add(pair.key, pair.value);
            }
            return dic;
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Span<KeyValuePair<TKey, TValue>> span)
            where TKey : notnull
        {
            return ToDictionary(span, EqualityComparer<TKey>.Default);
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue, TComparer>(this Span<KeyValuePair<TKey, TValue>> span, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
            where TKey : notnull
        {
            var dic = new Dictionary<TKey, TValue>(span.Length, comparer);
            foreach (var pair in span)
            {
                dic.Add(pair.Key, pair.Value);
            }
            return dic;
        }


        public static Dictionary<TKey, T> ToDictionary<T, TKey>(this Span<T> span, Func<T, TKey> keySelector)
            where TKey : notnull
        {
            return ToDictionary(span, keySelector, i => i, EqualityComparer<TKey>.Default);
        }

        public static Dictionary<TKey, T> ToDictionary<T, TKey, TComparer>(this Span<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
            where TKey : notnull
        {
            return ToDictionary(span, keySelector, i => i, comparer);
        }

        public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(this Span<T> span, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)
            where TKey : notnull
        {
            return ToDictionary(span, keySelector, valueSelector, EqualityComparer<TKey>.Default);
        }

        public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue, TComparer>(this Span<T> span, Func<T, TKey> keySelector, Func<T, TValue> valueSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
            where TKey : notnull
        {
            var dic = new Dictionary<TKey, TValue>(span.Length, comparer);
            foreach (var element in span)
            {
                dic.Add(keySelector(element), valueSelector(element));
            }
            return dic;
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public Dictionary<TKey, TOut> ToDictionary<TKey>(Func<TOut, TKey> keySelector)
            where TKey : notnull
        {
            return ToDictionary(keySelector, i => i, EqualityComparer<TKey>.Default);
        }

        public Dictionary<TKey, TOut> ToDictionary<TKey, TComparer>(Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
            where TKey : notnull
        {
            return ToDictionary(keySelector, i => i, comparer);
        }

        public Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(Func<TOut, TKey> keySelector, Func<TOut, TValue> valueSelector)
            where TKey : notnull
        {
            return ToDictionary(keySelector, valueSelector, EqualityComparer<TKey>.Default);
        }

        public Dictionary<TKey, TValue> ToDictionary<TKey, TValue, TComparer>(Func<TOut, TKey> keySelector, Func<TOut, TValue> valueSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
            where TKey : notnull
        {
            var sourceSpan = ToArrayPool(out var sourceArray);

            var dic = new Dictionary<TKey, TValue>(sourceSpan.Length, comparer);
            foreach (var element in sourceSpan)
            {
                dic.Add(keySelector(element), valueSelector(element));
            }

            ArrayPool<TOut>.Shared.Return(sourceArray);
            return dic;
        }
    }
}
