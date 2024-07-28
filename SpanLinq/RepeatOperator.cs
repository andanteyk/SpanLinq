namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, RepeatOperator<T>> Repeat<T>(T element, int count)
        {
            return new(ReadOnlySpan<T>.Empty, new(element, count));
        }
    }

    public struct RepeatOperator<TSpan> : ISpanOperator<TSpan, TSpan>
    {
        private readonly TSpan Element;
        private int Count;

        internal RepeatOperator(TSpan element, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();

            Element = element;
            Count = count;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = Count;
            return true;
        }

        public TSpan TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Count == 0)
            {
                success = false;
                return default!;
            }

            success = true;
            Count--;
            return Element;
        }
    }
}
