using System.Buffers;
#if !NET8_0_OR_GREATER
using System.Runtime.CompilerServices;
#endif

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static List<T> ToList<T>(this ReadOnlySpan<T> span)
        {
            var list = new List<T>(span.Length);

#if NET8_0_OR_GREATER
            CollectionExtensions.AddRange(list, span);
#else
            var cloneList = Unsafe.As<List<T>, ListClone<T>>(ref list);
            span.CopyTo(cloneList._items);
            cloneList._size = span.Length;
#endif

            return list;
        }

        public static List<T> ToList<T>(this Span<T> span)
        {
            return ToList((ReadOnlySpan<T>)span);
        }

        internal class ListClone<T>
        {
#pragma warning disable CS0649
            internal T[]? _items;
            internal int _size;
            internal int _version;
#pragma warning restore

#if NETFRAMEWORK
        internal object _syncRoot;
#endif
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public List<TOut> ToList()
        {
            var sourceSpan = ToArrayPool(out var sourceArray);

            var list = new List<TOut>(sourceSpan.Length);

#if NET8_0_OR_GREATER
            CollectionExtensions.AddRange(list, sourceSpan);
#else
            var cloneList = Unsafe.As<List<TOut>, SpanEnumerable.ListClone<TOut>>(ref list);
            sourceSpan.CopyTo(cloneList._items);
            cloneList._size = sourceSpan.Length;
#endif

            ArrayPool<TOut>.Shared.Return(sourceArray);
            return list;
        }
    }
}
