namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TIn, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TIn, TIn, TKey, TAccumulate, TComparer, IdentityOperator<TIn>>> AggregateBy<TIn, TKey, TAccumulate, TComparer>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TAccumulate> seedSelector, Func<TAccumulate, TIn, TAccumulate> accumulator, TComparer keyComparer)
            where TKey : notnull
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, seedSelector, accumulator, keyComparer));
        }

        public static SpanEnumerator<TIn, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TIn, TIn, TKey, TAccumulate, TComparer, IdentityOperator<TIn>>> AggregateBy<TIn, TKey, TAccumulate, TComparer>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TIn, TAccumulate> accumulator, TComparer keyComparer)
            where TKey : notnull
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, seed, accumulator, keyComparer));
        }

        public static SpanEnumerator<TIn, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TIn, TIn, TKey, TAccumulate, EqualityComparer<TKey>, IdentityOperator<TIn>>> AggregateBy<TIn, TKey, TAccumulate>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TAccumulate> seedSelector, Func<TAccumulate, TIn, TAccumulate> accumulator)
            where TKey : notnull
        {
            return new(span, new(new(), keySelector, seedSelector, accumulator, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TIn, TIn, TKey, TAccumulate, EqualityComparer<TKey>, IdentityOperator<TIn>>> AggregateBy<TIn, TKey, TAccumulate>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TIn, TAccumulate> accumulator)
            where TKey : notnull
        {
            return new(span, new(new(), keySelector, seed, accumulator, EqualityComparer<TKey>.Default));
        }


        public static SpanEnumerator<TIn, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TIn, TIn, TKey, TAccumulate, TComparer, IdentityOperator<TIn>>> AggregateBy<TIn, TKey, TAccumulate, TComparer>(this Span<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TAccumulate> seedSelector, Func<TAccumulate, TIn, TAccumulate> accumulator, TComparer keyComparer)
            where TKey : notnull
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, seedSelector, accumulator, keyComparer));
        }

        public static SpanEnumerator<TIn, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TIn, TIn, TKey, TAccumulate, TComparer, IdentityOperator<TIn>>> AggregateBy<TIn, TKey, TAccumulate, TComparer>(this Span<TIn> span, Func<TIn, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TIn, TAccumulate> accumulator, TComparer keyComparer)
            where TKey : notnull
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, seed, accumulator, keyComparer));
        }

        public static SpanEnumerator<TIn, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TIn, TIn, TKey, TAccumulate, EqualityComparer<TKey>, IdentityOperator<TIn>>> AggregateBy<TIn, TKey, TAccumulate>(this Span<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TAccumulate> seedSelector, Func<TAccumulate, TIn, TAccumulate> accumulator)
            where TKey : notnull
        {
            return new(span, new(new(), keySelector, seedSelector, accumulator, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TIn, TIn, TKey, TAccumulate, EqualityComparer<TKey>, IdentityOperator<TIn>>> AggregateBy<TIn, TKey, TAccumulate>(this Span<TIn> span, Func<TIn, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TIn, TAccumulate> accumulator)
            where TKey : notnull
        {
            return new(span, new(new(), keySelector, seed, accumulator, EqualityComparer<TKey>.Default));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TSource, TOut, TKey, TAccumulate, TComparer, TOperator>> AggregateBy<TKey, TAccumulate, TComparer>(Func<TOut, TKey> keySelector, Func<TOut, TAccumulate> seedSelector, Func<TAccumulate, TOut, TAccumulate> accumulator, TComparer keyComparer)
            where TKey : notnull
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, seedSelector, accumulator, keyComparer));
        }

        public SpanEnumerator<TSource, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TSource, TOut, TKey, TAccumulate, TComparer, TOperator>> AggregateBy<TKey, TAccumulate, TComparer>(Func<TOut, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TOut, TAccumulate> accumulator, TComparer keyComparer)
            where TKey : notnull
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, seed, accumulator, keyComparer));
        }

        public SpanEnumerator<TSource, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TSource, TOut, TKey, TAccumulate, EqualityComparer<TKey>, TOperator>> AggregateBy<TKey, TAccumulate>(Func<TOut, TKey> keySelector, Func<TOut, TAccumulate> seedSelector, Func<TAccumulate, TOut, TAccumulate> accumulator)
            where TKey : notnull
        {
            return new(Source, new(Operator, keySelector, seedSelector, accumulator, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, KeyValuePair<TKey, TAccumulate>, AggregateByOperator<TSource, TOut, TKey, TAccumulate, EqualityComparer<TKey>, TOperator>> AggregateBy<TKey, TAccumulate>(Func<TOut, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TOut, TAccumulate> accumulator)
            where TKey : notnull
        {
            return new(Source, new(Operator, keySelector, seed, accumulator, EqualityComparer<TKey>.Default));
        }
    }

    public struct AggregateByOperator<TSpan, TIn, TKey, TAccumulate, TComparer, TOperator> : ISpanOperator<TSpan, KeyValuePair<TKey, TAccumulate>>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IEqualityComparer<TKey>
        where TKey : notnull
    {
        internal TOperator Operator;
        internal readonly Func<TIn, TKey> KeySelector;
        internal readonly Func<TIn, TAccumulate>? SeedSelector;
        internal readonly TAccumulate Seed;
        internal readonly Func<TAccumulate, TIn, TAccumulate> Accumulator;
        internal readonly TComparer KeyComparer;

        internal ArrayPoolDictionary<TKey, TAccumulate> Dictionary;
        internal ArrayPoolDictionary<TKey, TAccumulate>.Enumerator DictionaryEnumerator;

        internal AggregateByOperator(TOperator op, Func<TIn, TKey> keySelector, Func<TIn, TAccumulate> seedSelector, Func<TAccumulate, TIn, TAccumulate> accumulator, TComparer keyComparer)
        {
            Operator = op;
            KeySelector = keySelector;
            SeedSelector = seedSelector;
            Seed = default!;
            Accumulator = accumulator;
            KeyComparer = keyComparer;
            Dictionary = null!;
            DictionaryEnumerator = default;
        }

        internal AggregateByOperator(TOperator op, Func<TIn, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TIn, TAccumulate> accumulator, TComparer keyComparer)
        {
            Operator = op;
            KeySelector = keySelector;
            SeedSelector = null;
            Seed = seed;
            Accumulator = accumulator;
            KeyComparer = keyComparer;
            Dictionary = null!;
            DictionaryEnumerator = default;
        }


        public readonly bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public KeyValuePair<TKey, TAccumulate> TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Dictionary == null)
            {
                Dictionary = ObjectPool.SharedRent<ArrayPoolDictionary<TKey, TAccumulate>>();
                Dictionary.ClearAndSetComparer(KeyComparer);

                while (true)
                {
                    var current = Operator.TryMoveNext(ref source, out bool ok);
                    if (!ok)
                    {
                        break;
                    }

                    var key = KeySelector(current);
                    if (Dictionary.TryGetValue(key, out TAccumulate? value))
                    {
                        Dictionary[key] = Accumulator(value, current);
                    }
                    else
                    {
                        Dictionary[key] = SeedSelector != null ? SeedSelector(current) : Accumulator(Seed, current);
                    }
                }

                DictionaryEnumerator = Dictionary.GetEnumerator();
            }

            if (DictionaryEnumerator.MoveNext())
            {
                success = true;
                return DictionaryEnumerator.Current;
            }
            else
            {
                Dispose();
                success = false;
                return default!;
            }
        }

        public void Dispose()
        {
            if (Dictionary != null)
            {
                ObjectPool.SharedReturn(Dictionary);
                Dictionary = null!;
            }
        }
    }
}
