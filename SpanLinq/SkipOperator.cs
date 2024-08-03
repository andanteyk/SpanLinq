namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, SkipOperator<T, T, IdentityOperator<T>>> Skip<T>(this ReadOnlySpan<T> span, int skipCount)
        {
            return new(span, new(new(), skipCount));
        }

        public static SpanEnumerator<T, T, SkipOperator<T, T, IdentityOperator<T>>> Skip<T>(this Span<T> span, int skipCount)
        {
            return new(span, new(new(), skipCount));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, SkipOperator<TSource, TOut, TOperator>> Skip(int skipCount)
        {
            return new(Source, new(Operator, skipCount));
        }
    }

    public struct SkipOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal int SkipCount;

        internal SkipOperator(TOperator op, int skipCount)
        {
            Operator = op;
            SkipCount = skipCount;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            if (Operator.TryGetNonEnumeratedCount(source, out length))
            {
                length = Math.Max(length - Math.Max(SkipCount, 0), 0);
                return true;
            }
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (SkipCount > 0 && Operator is IdentityOperator<TIn>)
            {
                source = source[Math.Min(SkipCount, source.Length)..];
                SkipCount = 0;
            }

            while (SkipCount > 0)
            {
                Operator.TryMoveNext(ref source, out bool ok);
                if (!ok)
                {
                    success = false;
                    return default!;
                }
                SkipCount--;
            }

            return Operator.TryMoveNext(ref source, out success);
        }
    }
}
