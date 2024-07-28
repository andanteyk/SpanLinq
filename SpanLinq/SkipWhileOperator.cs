namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, SkipWhileOperator<T, T, IdentityOperator<T>>> SkipWhile<T>(this ReadOnlySpan<T> span, Func<T, bool> predicate)
        {
            return new(span, new(new(), (x, _) => predicate(x)));
        }

        public static SpanEnumerator<T, T, SkipWhileOperator<T, T, IdentityOperator<T>>> SkipWhile<T>(this ReadOnlySpan<T> span, Func<T, int, bool> predicate)
        {
            return new(span, new(new(), predicate));
        }

        public static SpanEnumerator<T, T, SkipWhileOperator<T, T, IdentityOperator<T>>> SkipWhile<T>(this Span<T> span, Func<T, bool> predicate)
        {
            return new(span, new(new(), (x, _) => predicate(x)));
        }

        public static SpanEnumerator<T, T, SkipWhileOperator<T, T, IdentityOperator<T>>> SkipWhile<T>(this Span<T> span, Func<T, int, bool> predicate)
        {
            return new(span, new(new(), predicate));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, SkipWhileOperator<TSource, TOut, TOperator>> SkipWhile(Func<TOut, bool> predicate)
        {
            return new(Source, new(Operator, (x, _) => predicate(x)));
        }

        public SpanEnumerator<TSource, TOut, SkipWhileOperator<TSource, TOut, TOperator>> SkipWhile(Func<TOut, int, bool> predicate)
        {
            return new(Source, new(Operator, predicate));
        }
    }

    public struct SkipWhileOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal Func<TIn, int, bool> Predicate;
        internal int Index;

        internal SkipWhileOperator(TOperator op, Func<TIn, int, bool> predicate)
        {
            Operator = op;
            Predicate = predicate;
            Index = -1;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Index == -1)
            {
                while (true)
                {
                    var current = Operator.TryMoveNext(ref source, out bool ok);
                    if (!ok)
                    {
                        success = false;
                        return default!;
                    }
                    if (!Predicate(current, ++Index))
                    {
                        success = true;
                        return current;
                    }
                }
            }

            return Operator.TryMoveNext(ref source, out success);
        }
    }
}
