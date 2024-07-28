namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T Aggregate<T>(this ReadOnlySpan<T> span, Func<T, T, T> accumulator)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Aggregate(accumulator);
        }

        public static TAccumulate Aggregate<T, TAccumulate>(this ReadOnlySpan<T> span, TAccumulate seed, Func<TAccumulate, T, TAccumulate> accumulator)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Aggregate(seed, accumulator);
        }

        public static TResult Aggregate<T, TAccumulate, TResult>(this ReadOnlySpan<T> span, TAccumulate seed, Func<TAccumulate, T, TAccumulate> accumulator, Func<TAccumulate, TResult> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Aggregate(seed, accumulator, selector);
        }


        public static T Aggregate<T>(this Span<T> span, Func<T, T, T> accumulator)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Aggregate(accumulator);
        }

        public static TAccumulate Aggregate<T, TAccumulate>(this Span<T> span, TAccumulate seed, Func<TAccumulate, T, TAccumulate> accumulator)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Aggregate(seed, accumulator);
        }

        public static TResult Aggregate<T, TAccumulate, TResult>(this Span<T> span, TAccumulate seed, Func<TAccumulate, T, TAccumulate> accumulator, Func<TAccumulate, TResult> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Aggregate(seed, accumulator, selector);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public TOut Aggregate(Func<TOut, TOut, TOut> accumulator)
        {
            var seed = Operator.TryMoveNext(ref Source, out bool ok);
            if (!ok)
            {
                throw new InvalidOperationException();
            }

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out ok);
                if (!ok)
                {
                    break;
                }

                seed = accumulator(seed, current);
            }

            return seed;
        }

        public TAccumulate Aggregate<TAccumulate>(TAccumulate seed, Func<TAccumulate, TOut, TAccumulate> accumulator)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }

                seed = accumulator(seed, current);
            }

            return seed;
        }

        public TResult Aggregate<TAccumulate, TResult>(TAccumulate seed, Func<TAccumulate, TOut, TAccumulate> accumulator, Func<TAccumulate, TResult> selector)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }

                seed = accumulator(seed, current);
            }

            return selector(seed);
        }
    }
}
