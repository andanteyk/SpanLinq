using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static HashSet<T> ToHashSet<T>(this ReadOnlySpan<T> span)
        {
            return ToHashSet(span, EqualityComparer<T>.Default);
        }

        public static HashSet<T> ToHashSet<T, TComparer>(this ReadOnlySpan<T> span, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            var set = new HashSet<T>(span.Length, comparer);
            foreach (var element in span)
            {
                set.Add(element);
            }
            return set;
        }


        public static HashSet<T> ToHashSet<T>(this Span<T> span)
        {
            return ToHashSet(span, EqualityComparer<T>.Default);
        }

        public static HashSet<T> ToHashSet<T, TComparer>(this Span<T> span, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            var set = new HashSet<T>(span.Length, comparer);
            foreach (var element in span)
            {
                set.Add(element);
            }
            return set;
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public HashSet<TOut> ToHashSet()
        {
            return ToHashSet(EqualityComparer<TOut>.Default);
        }

        public HashSet<TOut> ToHashSet<TComparer>(TComparer comparer)
            where TComparer : IEqualityComparer<TOut>
        {
            var sourceSpan = ToArrayPool(out var sourceArray);

            var set = new HashSet<TOut>(sourceSpan.Length, comparer);
            foreach (var element in sourceSpan)
            {
                set.Add(element);
            }

            ArrayPool<TOut>.Shared.Return(sourceArray);
            return set;
        }
    }
}
