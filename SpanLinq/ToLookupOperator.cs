using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static ILookup<TKey, T> ToLookup<T, TKey>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector)
        {
            return ToLookup(span, keySelector, i => i, EqualityComparer<TKey>.Default);
        }

        public static ILookup<TKey, T> ToLookup<T, TKey, TComparer>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return ToLookup(span, keySelector, i => i, comparer);
        }

        public static ILookup<TKey, TElement> ToLookup<T, TKey, TElement>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
        {
            return ToLookup(span, keySelector, elementSelector, EqualityComparer<TKey>.Default);
        }

        public static ILookup<TKey, TElement> ToLookup<T, TKey, TElement, TComparer>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            var sourceArray = ArrayPool<T>.Shared.Rent(span.Length);
            span.CopyTo(sourceArray);
            var result = sourceArray.Take(span.Length).ToLookup(keySelector, elementSelector, comparer);
            ArrayPool<T>.Shared.Return(sourceArray);
            return result;
        }



        public static ILookup<TKey, T> ToLookup<T, TKey>(this Span<T> span, Func<T, TKey> keySelector)
        {
            return ToLookup(span, keySelector, i => i, EqualityComparer<TKey>.Default);
        }

        public static ILookup<TKey, T> ToLookup<T, TKey, TComparer>(this Span<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return ToLookup(span, keySelector, i => i, comparer);
        }

        public static ILookup<TKey, TElement> ToLookup<T, TKey, TElement>(this Span<T> span, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
        {
            return ToLookup(span, keySelector, elementSelector, EqualityComparer<TKey>.Default);
        }

        public static ILookup<TKey, TElement> ToLookup<T, TKey, TElement, TComparer>(this Span<T> span, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            var sourceArray = ArrayPool<T>.Shared.Rent(span.Length);
            span.CopyTo(sourceArray);
            var result = sourceArray.Take(span.Length).ToLookup(keySelector, elementSelector, comparer);
            ArrayPool<T>.Shared.Return(sourceArray);
            return result;
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public ILookup<TKey, TOut> ToLookup<TKey>(Func<TOut, TKey> keySelector)
        {
            return ToLookup(keySelector, EqualityComparer<TKey>.Default);
        }

        public ILookup<TKey, TOut> ToLookup<TKey, TComparer>(Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            var sourceSpan = ToArrayPool(out var sourceArray);
            var result = sourceArray.Take(sourceSpan.Length).ToLookup(keySelector, comparer);
            ArrayPool<TOut>.Shared.Return(sourceArray);
            return result;
        }

        public ILookup<TKey, TElement> ToLookup<TKey, TElement>(Func<TOut, TKey> keySelector, Func<TOut, TElement> elementSelector)
        {
            return ToLookup(keySelector, elementSelector, EqualityComparer<TKey>.Default);
        }

        public ILookup<TKey, TElement> ToLookup<TKey, TElement, TComparer>(Func<TOut, TKey> keySelector, Func<TOut, TElement> elementSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            var sourceSpan = ToArrayPool(out var sourceArray);
            var result = sourceArray.Take(sourceSpan.Length).ToLookup(keySelector, elementSelector, comparer);
            ArrayPool<TOut>.Shared.Return(sourceArray);
            return result;
        }
    }
}
