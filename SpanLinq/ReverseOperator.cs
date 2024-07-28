using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, ReverseOperator<T, T, IdentityOperator<T>>> Reverse<T>(this ReadOnlySpan<T> span)
        {
            return new(span, new(new()));
        }

        public static SpanEnumerator<T, T, ReverseOperator<T, T, IdentityOperator<T>>> Reverse<T>(this Span<T> span)
        {
            return new(span, new(new()));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, ReverseOperator<TSource, TOut, TOperator>> Reverse()
        {
            return new(Source, new(Operator));
        }
    }

    public struct ReverseOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal TIn[] Source;
        internal int Index;

        internal ReverseOperator(TOperator op)
        {
            Operator = op;
            Source = null!;
            Index = int.MinValue;
        }

        public void Dispose()
        {
            if (Source != null)
            {
                ArrayPool<TIn>.Shared.Return(Source);
                Source = null!;
            }
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            if (Operator.TryGetNonEnumeratedCount(source, out length))
            {
                return true;
            }
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Index == int.MinValue)
            {
                var sourceSpan = SpanEnumerator<TSpan, TIn, TOperator>.ToArrayPool(source, Operator, out Source);
                Index = sourceSpan.Length - 1;
            }
            if (Index == -1)
            {
                Dispose();
            }

            success = Index >= 0;
            return success ? Source![Index--] : default!;
        }
    }
}
