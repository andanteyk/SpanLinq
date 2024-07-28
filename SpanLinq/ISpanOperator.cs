namespace SpanLinq
{
    public interface ISpanOperator<TIn, TOut>
    {
        TOut TryMoveNext(ref ReadOnlySpan<TIn> source, out bool success);
        bool TryGetNonEnumeratedCount(ReadOnlySpan<TIn> source, out int length);
    }

    public interface ISpanOperator2<TIn1, TIn2, TOut>
    {
        TOut TryMoveNext(ref ReadOnlySpan<TIn1> source1, ref ReadOnlySpan<TIn2> source2, out bool success);
        bool TryGetNonEnumeratedCount(ReadOnlySpan<TIn1> source1, ReadOnlySpan<TIn2> source2, out int length);
    }
}
