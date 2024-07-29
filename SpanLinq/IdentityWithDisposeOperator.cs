namespace SpanLinq
{
    public readonly struct IdentityWithDisposeOperator<TSpan, TSource> : ISpanOperator<TSpan, TSpan>
        where TSource : IDisposable
    {
        internal readonly TSource Source;

        internal IdentityWithDisposeOperator(TSource source)
        {
            Source = source;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = source.Length;
            return true;
        }

        public TSpan TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (source.Length == 0)
            {
                if (Source is IDisposable disposable)
                {
                    disposable.Dispose();
                }
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
