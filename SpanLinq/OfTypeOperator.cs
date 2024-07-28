using System.Runtime.CompilerServices;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, TOut, OfTypeOperator<T, T, TOut, IdentityOperator<T>>> OfType<T, TOut>(this ReadOnlySpan<T> span)
        {
            return new(span, new(new()));
        }

        public static SpanEnumerator<T, TOut, OfTypeOperator<T, T, TOut, IdentityOperator<T>>> OfType<T, TOut>(this Span<T> span)
        {
            return new(span, new(new()));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOutNext, OfTypeOperator<TSource, TOut, TOutNext, TOperator>> OfType<TOutNext>()
        {
            return new(Source, new(Operator));
        }
    }

    public struct OfTypeOperator<TSpan, TIn, TOut, TOperator> : ISpanOperator<TSpan, TOut>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;

        internal OfTypeOperator(TOperator op)
        {
            Operator = op;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TOut TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref source, out bool ok);
                if (!ok)
                {
                    success = false;
                    return default!;
                }

                if (current == null)
                {
                    continue;
                }
                if (current is TOut currentTOut)
                {
                    success = true;
                    return currentTOut;
                }
            }
        }
    }
}
