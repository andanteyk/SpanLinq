namespace SpanLinq
{
    public readonly struct IdentityOperator<TSpan> : ISpanOperator<TSpan, TSpan>
    {
        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = source.Length;
            return true;
        }

        public TSpan TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            while (true)
            {
                if (source.Length == 0)
                {
                    success = false;
                    return default!;
                }
                var current = source[0];
                source = source[1..];
                success = true;
                return current;
            }
        }
    }
}
