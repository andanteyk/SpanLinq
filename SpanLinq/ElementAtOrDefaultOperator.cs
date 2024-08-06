using System.Buffers;
using System.Runtime.CompilerServices;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T? ElementAtOrDefault<T>(this ReadOnlySpan<T> span, int index)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).ElementAtOrDefault(index);
        }

        public static T? ElementAtOrDefault<T>(this ReadOnlySpan<T> span, Index index)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).ElementAtOrDefault(index);
        }


        public static T? ElementAtOrDefault<T>(this Span<T> span, int index)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).ElementAtOrDefault(index);
        }

        public static T? ElementAtOrDefault<T>(this Span<T> span, Index index)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).ElementAtOrDefault(index);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public TOut? ElementAtOrDefault(int index)
        {
            if (index < 0)
                return default;

            return ElementAtOrDefault(new Index(index));
        }

        public TOut? ElementAtOrDefault(Index index)
        {
            if (Operator is IdentityOperator<TSource>)
            {
                var span = Source;

                if ((index.IsFromEnd && span.Length - 1 - index.Value >= 0) ||
                    (!index.IsFromEnd && index.Value < span.Length))
                {
                    var value = span[index];
                    return Unsafe.As<TSource, TOut>(ref value);         // here, TSource == TOut.
                }
                else
                {
                    return default;
                }
            }

            return ElementAtOrDefaultFallback(index);
        }


        private TOut? ElementAtOrDefaultFallback(Index index)
        {
            var span = ToArrayPool(out var poolingArray);
            try
            {
                if ((index.IsFromEnd && span.Length - 1 - index.Value >= 0) ||
                    (!index.IsFromEnd && index.Value < span.Length))
                {
                    return span[index];
                }
                else
                {
                    return default;
                }
            }
            finally
            {
                ArrayPool<TOut>.Shared.Return(poolingArray);
            }
        }
    }
}
