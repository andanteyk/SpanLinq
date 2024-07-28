namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, EmptyOperator<T>> Empty<T>()
        {
            return new(ReadOnlySpan<T>.Empty, new());
        }
    }

    public readonly struct EmptyOperator<TSpan> : ISpanOperator<TSpan, TSpan>
    {
        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = 0;
            return true;
        }

        public TSpan TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            success = false;
            return default!;
        }
    }
}
