namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, FromEnumerableOperator<T>> FromEnumerable<T>(IEnumerable<T> sequence)
        {
            return new(ReadOnlySpan<T>.Empty, new(sequence));
        }
    }

    public struct FromEnumerableOperator<TSpan> : ISpanOperator<TSpan, TSpan>
    {
        private IEnumerable<TSpan> Sequence;
        private IEnumerator<TSpan> Enumerator;

        internal FromEnumerableOperator(IEnumerable<TSpan> sequence)
        {
            Sequence = sequence;
            Enumerator = default!;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TSpan TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Enumerator == default)
            {
                Enumerator = Sequence.GetEnumerator();
            }

            if (Enumerator.MoveNext())
            {
                success = true;
                return Enumerator.Current;
            }
            success = false;
            return default!;
        }
    }
}
