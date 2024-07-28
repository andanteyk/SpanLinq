using System.Runtime.CompilerServices;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TIn, TOut, CastOperator<TIn, TIn, TOut, IdentityOperator<TIn>>> Cast<TIn, TOut>(this ReadOnlySpan<TIn> span)
        {
            return new(span, new(new()));
        }

        public static SpanEnumerator<TIn, TOut, CastOperator<TIn, TIn, TOut, IdentityOperator<TIn>>> Cast<TIn, TOut>(this Span<TIn> span)
        {
            return new(span, new(new()));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOutNext, CastOperator<TSource, TOut, TOutNext, TOperator>> Cast<TOutNext>()
        {
            return new(Source, new(Operator));
        }
    }

    public struct CastOperator<TSpan, TIn, TOut, TOperator> : ISpanOperator<TSpan, TOut>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;

        internal CastOperator(TOperator op)
        {
            Operator = op;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            return Operator.TryGetNonEnumeratedCount(source, out length);
        }

        public TOut TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            var current = Operator.TryMoveNext(ref source, out bool ok);
            if (!ok)
            {
                success = false;
                return default!;
            }

            // TODO: safety check
            success = true;
            if (typeof(TOut).IsAssignableFrom(typeof(TIn)))
            {
                return Unsafe.As<TIn, TOut>(ref current);
            }
            else
            {
                return (TOut)(object)current!;
            }
        }
    }
}
