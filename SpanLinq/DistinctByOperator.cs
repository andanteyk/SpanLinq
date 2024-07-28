using Microsoft.Diagnostics.Tracing;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, DistinctByOperator<T, T, IdentityOperator<T>, TKey, EqualityComparer<TKey>>> DistinctBy<T, TKey>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector)
        {
            return new(span, new(new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, DistinctByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> DistinctBy<T, TKey, TComparer>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, comparer));
        }

        public static SpanEnumerator<T, T, DistinctByOperator<T, T, IdentityOperator<T>, TKey, EqualityComparer<TKey>>> DistinctBy<T, TKey>(this Span<T> span, Func<T, TKey> keySelector)
        {
            return new(span, new(new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, DistinctByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> DistinctBy<T, TKey, TComparer>(this Span<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, DistinctByOperator<TSource, TOut, TOperator, TKey, EqualityComparer<TKey>>> DistinctBy<TKey>(Func<TOut, TKey> keySelector)
        {
            return new(Source, new(Operator, keySelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, TOut, DistinctByOperator<TSource, TOut, TOperator, TKey, TComparer>> DistinctBy<TKey, TComparer>(Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, comparer));
        }
    }

    public struct DistinctByOperator<TSpan, TIn, TOperator, TKey, TComparer> : ISpanOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator Operator;
        internal readonly Func<TIn, TKey> KeySelector;
        internal readonly TComparer Comparer;
        // TODO: it generates CS8714; no way to remove it without #nullable disable
#nullable disable
        internal ArrayPoolDictionary<TKey, TIn> Dictionary;
        internal ArrayPoolDictionary<TKey, TIn>.Enumerator DictionaryEnumerator;
#nullable restore
        internal KeyValuePair<int, TIn> ExistsNull;

        internal DistinctByOperator(TOperator op, Func<TIn, TKey> keySelector, TComparer comparer)
        {
            Operator = op;
            KeySelector = keySelector;
            Comparer = comparer;
            Dictionary = null!;
            DictionaryEnumerator = default;
            ExistsNull = default;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Dictionary == null)
            {
#nullable disable
                Dictionary = new ArrayPoolDictionary<TKey, TIn>(Comparer);
#nullable restore
                while (true)
                {
                    var current = Operator.TryMoveNext(ref source, out bool ok);
                    if (!ok)
                    {
                        break;
                    }

                    var key = KeySelector(current);

                    if (key == null)
                    {
                        if (ExistsNull.Key == 0)
                        {
                            ExistsNull = new KeyValuePair<int, TIn>(1, current);
                        }
                    }
                    else if (!Dictionary.ContainsKey(key))
                    {
                        Dictionary.Add(key, current);
                    }
                }

                DictionaryEnumerator = Dictionary.GetEnumerator();
            }

            if (ExistsNull.Key == 1)
            {
                var value = ExistsNull.Value;
                ExistsNull = new KeyValuePair<int, TIn>(-1, default!);
                success = true;
                return value;
            }

            if (DictionaryEnumerator.MoveNext())
            {
                success = true;
                return DictionaryEnumerator.Current.Value;
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
                Dictionary.Dispose();
                Dictionary = null!;
            }
        }
    }
}
