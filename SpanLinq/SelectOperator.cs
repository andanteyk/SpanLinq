namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TIn, TOut, SelectOperator<TIn, TIn, TOut, IdentityOperator<TIn>>> Select<TIn, TOut>(this ReadOnlySpan<TIn> span, Func<TIn, TOut> selector)
        {
            return new(span, new(new(), selector));
        }

        public static SpanEnumerator<TIn, TOut, SelectOperator<TIn, TIn, TOut, IdentityOperator<TIn>>> Select<TIn, TOut>(this Span<TIn> span, Func<TIn, TOut> selector)
        {
            return new(span, new(new(), selector));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOutNext, SelectOperator<TSource, TOut, TOutNext, TOperator>> Select<TOutNext>(Func<TOut, TOutNext> selector)
        {
            return new(Source, new(Operator, selector));
        }
    }

    public struct SelectOperator<TSpan, TIn, TOut, TOperator> : ISpanOperator<TSpan, TOut>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal readonly Func<TIn, TOut> Selector;

        internal SelectOperator(TOperator op, Func<TIn, TOut> selector)
        {
            Operator = op;
            Selector = selector;
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

            success = true;
            return Selector(current);
        }
    }
}
