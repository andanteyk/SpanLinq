namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TIn, (int Index, TIn Item), IndexOperator<TIn, TIn, IdentityOperator<TIn>>> Index<TIn>(this ReadOnlySpan<TIn> span)
        {
            return new(span, new(new()));
        }

        public static SpanEnumerator<TIn, (int Index, TIn Item), IndexOperator<TIn, TIn, IdentityOperator<TIn>>> Index<TIn>(this Span<TIn> span)
        {
            return new(span, new(new()));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, (int Index, TOut Item), IndexOperator<TSource, TOut, TOperator>> Index()
        {
            return new(Source, new(Operator));
        }
    }

    public struct IndexOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, (int Index, TIn Item)>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal int Index;

        internal IndexOperator(TOperator op)
        {
            Operator = op;
            Index = 0;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            return Operator.TryGetNonEnumeratedCount(source, out length);
        }

        public (int Index, TIn Item) TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            var current = Operator.TryMoveNext(ref source, out bool ok);
            if (!ok)
            {
                success = false;
                return default!;
            }

            success = true;
            return (Index++, current);
        }
    }
}
