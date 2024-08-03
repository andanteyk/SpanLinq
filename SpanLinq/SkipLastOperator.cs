using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, SkipLastOperator<T, T, IdentityOperator<T>>> SkipLast<T>(this ReadOnlySpan<T> span, int skipCount)
        {
            return new(span, new(new(), skipCount));
        }

        public static SpanEnumerator<T, T, SkipLastOperator<T, T, IdentityOperator<T>>> SkipLast<T>(this Span<T> span, int skipCount)
        {
            return new(span, new(new(), skipCount));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, SkipLastOperator<TSource, TOut, TOperator>> SkipLast(int skipCount)
        {
            return new(Source, new(Operator, skipCount));
        }
    }

    public struct SkipLastOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal int SkipCount;

        internal TIn[]? SourceArray;
        internal int SourceLength;
        internal int Index;

        internal SkipLastOperator(TOperator op, int skipCount)
        {
            Operator = op;
            SkipCount = Math.Max(skipCount, 0);

            SourceArray = null;
            SourceLength = -1;
            Index = -1;
        }

        public void Dispose()
        {
            if (SourceArray != null)
            {
                ArrayPool<TIn>.Shared.Return(SourceArray);
                SourceArray = null;
                Index = int.MinValue;
            }
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            if (Operator.TryGetNonEnumeratedCount(source, out length))
            {
                length = Math.Max(length - SkipCount, 0);
                return true;
            }
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Index == -1)
            {
                if (Operator is IdentityOperator<TIn>)
                {
                    SourceLength = Math.Max(source.Length - SkipCount, 0);
                    source = source[..SourceLength];
                    Index = 0;
                }
                else
                {
                    var sourceSpan = SpanEnumerator<TSpan, TIn, TOperator>.ToArrayPool(source, Operator, out SourceArray);
                    SourceLength = Math.Max(sourceSpan.Length - SkipCount, 0);
                    Index = 0;
                }
            }

            if (Index < SourceLength)
            {
                if (Operator is IdentityOperator<TIn>)
                {
                    return Operator.TryMoveNext(ref source, out success);
                }
                else
                {
                    success = true;
                    return SourceArray![Index++];
                }
            }
            else
            {
                Dispose();
            }

            success = false;
            return default!;
        }
    }
}
