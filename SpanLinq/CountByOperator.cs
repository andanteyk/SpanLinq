namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TIn, KeyValuePair<TKey, int>, CountByOperator<TIn, TIn, TKey, EqualityComparer<TKey>, IdentityOperator<TIn>>> CountBy<TIn, TKey>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector)
            where TKey : notnull
        {
            return new(span, new(new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, KeyValuePair<TKey, int>, CountByOperator<TIn, TIn, TKey, TComparer, IdentityOperator<TIn>>> CountBy<TIn, TKey, TComparer>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, TComparer keyComparer)
            where TKey : notnull
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, keyComparer));
        }


        public static SpanEnumerator<TIn, KeyValuePair<TKey, int>, CountByOperator<TIn, TIn, TKey, EqualityComparer<TKey>, IdentityOperator<TIn>>> CountBy<TIn, TKey>(this Span<TIn> span, Func<TIn, TKey> keySelector)
            where TKey : notnull
        {
            return new(span, new(new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, KeyValuePair<TKey, int>, CountByOperator<TIn, TIn, TKey, TComparer, IdentityOperator<TIn>>> CountBy<TIn, TKey, TComparer>(this Span<TIn> span, Func<TIn, TKey> keySelector, TComparer keyComparer)
            where TKey : notnull
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, keyComparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, KeyValuePair<TKey, int>, CountByOperator<TSource, TOut, TKey, EqualityComparer<TKey>, TOperator>> CountBy<TKey>(Func<TOut, TKey> keySelector)
            where TKey : notnull
        {
            return new(Source, new(Operator, keySelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, KeyValuePair<TKey, int>, CountByOperator<TSource, TOut, TKey, TComparer, TOperator>> CountBy<TKey, TComparer>(Func<TOut, TKey> keySelector, TComparer keyComparer)
            where TKey : notnull
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, keyComparer));
        }
    }

    public struct CountByOperator<TSpan, TIn, TKey, TComparer, TOperator> : ISpanOperator<TSpan, KeyValuePair<TKey, int>>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IEqualityComparer<TKey>
        where TKey : notnull
    {
        internal TOperator Operator;
        internal readonly Func<TIn, TKey> KeySelector;
        internal readonly TComparer KeyComparer;
        internal ArrayPoolDictionary<TKey, int> Dictionary;
        internal ArrayPoolDictionary<TKey, int>.Enumerator DictionaryEnumerator;

        internal CountByOperator(TOperator op, Func<TIn, TKey> keySelector, TComparer keyComparer)
        {
            Operator = op;
            KeySelector = keySelector;
            KeyComparer = keyComparer;
            Dictionary = null!;
            DictionaryEnumerator = default;
        }

        public readonly bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public KeyValuePair<TKey, int> TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Dictionary == null)
            {
                Dictionary = ObjectPool.SharedRent<ArrayPoolDictionary<TKey, int>>();
                Dictionary.ClearAndSetComparer(KeyComparer);

                while (true)
                {
                    var current = Operator.TryMoveNext(ref source, out bool ok);
                    if (!ok)
                    {
                        break;
                    }

                    var key = KeySelector(current);
                    if (Dictionary.TryGetValue(key, out int value))
                    {
                        Dictionary[key] = value + 1;
                    }
                    else
                    {
                        Dictionary[key] = 1;
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
