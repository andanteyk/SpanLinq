namespace SpanLinq
{
    public interface ISpanOperator<TIn, TOut>
    {
        TOut TryMoveNext(ref ReadOnlySpan<TIn> source, out bool success);
        bool TryGetNonEnumeratedCount(ReadOnlySpan<TIn> source, out int length);
    }
}
