using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T[] ToArray<T>(this ReadOnlySpan<T> span)
        {
            var result = new T[span.Length];
            span.CopyTo(result);
            return result;
        }

        public static T[] ToArray<T>(this Span<T> span)
        {
            var result = new T[span.Length];
            span.CopyTo(result);
            return result;
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        internal static TOut[] ToArray(ReadOnlySpan<TSource> source, TOperator op)
        {
            if (op.TryGetNonEnumeratedCount(source, out int length))
            {
                var result = new TOut[length];
                int i = 0;
                while (true)
                {
                    var current = op.TryMoveNext(ref source, out bool ok);
                    if (!ok)
                    {
                        break;
                    }
                    result[i++] = current;
                }
                return result;
            }
            else
            {
                var span = ToArrayPool(source, op, out var poolingArray);
                var result = new TOut[span.Length];
                span.CopyTo(result);
                ArrayPool<TOut>.Shared.Return(poolingArray);
                return result;
            }
        }

        public TOut[] ToArray()
        {
            return ToArray(Source, Operator);
        }
    }
}
