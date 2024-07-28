namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<int, int, RangeOperator<int>> Range(int start, int count)
        {
            return new(ReadOnlySpan<int>.Empty, new(start, count));
        }
    }

    public struct RangeOperator<TSpan> : ISpanOperator<TSpan, int>
    {
        internal readonly int End;
        private int Current;

        internal RangeOperator(int start, int count)
        {
            if (count < 0 || (start + count - 1) <= 0)
                throw new ArgumentOutOfRangeException();

            Current = start;
            End = start + count;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = End - Current;
            return true;
        }

        public int TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Current == End)
            {
                success = false;
                return default!;
            }

            success = true;
            return Current++;
        }
    }
}
