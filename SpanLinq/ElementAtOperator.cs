using System.Buffers;
using System.Runtime.CompilerServices;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T ElementAt<T>(this ReadOnlySpan<T> span, int index)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).ElementAt(index);
        }

        public static T ElementAt<T>(this ReadOnlySpan<T> span, Index index)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).ElementAt(index);
        }


        public static T ElementAt<T>(this Span<T> span, int index)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).ElementAt(index);
        }

        public static T ElementAt<T>(this Span<T> span, Index index)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).ElementAt(index);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public TOut ElementAt(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException();

            return ElementAt(new Index(index));
        }

        public TOut ElementAt(Index index)
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
                    throw new ArgumentOutOfRangeException();
                }
            }

            return ElementAtFallback(index);
        }


        private TOut ElementAtFallback(Index index)
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
                    throw new ArgumentOutOfRangeException();
                }
            }
            finally
            {
                ArrayPool<TOut>.Shared.Return(poolingArray);
            }
        }
    }
}
