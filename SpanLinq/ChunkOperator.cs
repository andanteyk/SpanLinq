
namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T[], ChunkOperator<T, T, IdentityOperator<T>>> Chunk<T>(this ReadOnlySpan<T> span, int count)
        {
            return new(span, new(new(), count));
        }

        public static SpanEnumerator<T, T[], ChunkOperator<T, T, IdentityOperator<T>>> Chunk<T>(this Span<T> span, int count)
        {
            return new(span, new(new(), count));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut[], ChunkOperator<TSource, TOut, TOperator>> Chunk(int count)
        {
            return new(Source, new(Operator, count));
        }
    }

    public struct ChunkOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn[]>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal readonly int Count;

        internal ChunkOperator(TOperator op, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Operator = op;
            Count = count;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            if (Operator.TryGetNonEnumeratedCount(source, out length))
            {
                int div = Math.DivRem(length, Count, out int rem);
                length = div + (rem > 0 ? 1 : 0);
                return true;
            }

            return false;
        }

        public TIn[] TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            var current = Operator.TryMoveNext(ref source, out bool ok);
            if (!ok)
            {
                success = false;
                return default!;
            }

            var result = new TIn[Count];
            result[0] = current;

            for (int i = 1; i < Count; i++)
            {
                current = Operator.TryMoveNext(ref source, out ok);
                if (!ok)
                {
                    // TODO: memory allocation
                    var shrinkedResult = new TIn[i];
                    result.AsSpan(..i).CopyTo(shrinkedResult);
                    result = shrinkedResult;
                    break;
                }
                result[i] = current;
            }

            success = true;
            return result;
        }
    }
}
