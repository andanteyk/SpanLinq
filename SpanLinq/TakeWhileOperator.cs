namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, TakeWhileOperator<T, T, IdentityOperator<T>>> TakeWhile<T>(this ReadOnlySpan<T> span, Func<T, bool> predicate)
        {
            return new(span, new(new(), predicate));
        }

        public static SpanEnumerator<T, T, TakeWhileOperator<T, T, IdentityOperator<T>>> TakeWhile<T>(this ReadOnlySpan<T> span, Func<T, int, bool> predicate)
        {
            return new(span, new(new(), predicate));
        }

        public static SpanEnumerator<T, T, TakeWhileOperator<T, T, IdentityOperator<T>>> TakeWhile<T>(this Span<T> span, Func<T, bool> predicate)
        {
            return new(span, new(new(), predicate));
        }

        public static SpanEnumerator<T, T, TakeWhileOperator<T, T, IdentityOperator<T>>> TakeWhile<T>(this Span<T> span, Func<T, int, bool> predicate)
        {
            return new(span, new(new(), predicate));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, TakeWhileOperator<TSource, TOut, TOperator>> TakeWhile(Func<TOut, bool> predicate)
        {
            return new(Source, new(Operator, predicate));
        }

        public SpanEnumerator<TSource, TOut, TakeWhileOperator<TSource, TOut, TOperator>> TakeWhile(Func<TOut, int, bool> predicate)
        {
            return new(Source, new(Operator, predicate));
        }
    }

    public struct TakeWhileOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal Delegate Predicate;
        internal int Index;


        internal TakeWhileOperator(TOperator op, Func<TIn, bool> predicate)
        {
            Operator = op;
            Predicate = predicate;
            Index = 0;
        }

        internal TakeWhileOperator(TOperator op, Func<TIn, int, bool> predicate)
        {
            Operator = op;
            Predicate = predicate;
            Index = 0;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Index >= 0)
            {
                var current = Operator.TryMoveNext(ref source, out bool ok);
                if (!ok)
                {
                    success = false;
                    return default!;
                }

                Index++;
                bool predicateResult = Predicate switch
                {
                    Func<TIn, bool> predicate => predicate(current),
                    Func<TIn, int, bool> predicate => predicate(current, Index),
                    _ => throw new InvalidOperationException()     // never reach here
                };
                if (predicateResult)
                {
                    success = true;
                    return current;
                }
                else
                {
                    Index = int.MinValue;
                }
            }

            success = false;
            return default!;
        }
    }
}
