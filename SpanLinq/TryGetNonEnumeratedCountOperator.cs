namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static bool TryGetNonEnumeratedCount<T>(this ReadOnlySpan<T> span, out int length)
        {
            length = span.Length;
            return true;
        }

        public static bool TryGetNonEnumeratedCount<T>(this Span<T> span, out int length)
        {
            length = span.Length;
            return true;
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public bool TryGetNonEnumeratedCount(out int length)
        {
            return Operator.TryGetNonEnumeratedCount(Source, out length);
        }
    }
}
