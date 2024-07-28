namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, DistinctOperator<T, T, IdentityOperator<T>, EqualityComparer<T>>> Distinct<T>(this ReadOnlySpan<T> span)
        {
            return new(span, new(new(), EqualityComparer<T>.Default));
        }

        public static SpanEnumerator<T, T, DistinctOperator<T, T, IdentityOperator<T>, TComparer>> Distinct<T, TComparer>(this ReadOnlySpan<T> span, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new(span, new(new(), comparer));
        }

        public static SpanEnumerator<T, T, DistinctOperator<T, T, IdentityOperator<T>, EqualityComparer<T>>> Distinct<T>(this Span<T> span)
        {
            return new(span, new(new(), EqualityComparer<T>.Default));
        }

        public static SpanEnumerator<T, T, DistinctOperator<T, T, IdentityOperator<T>, TComparer>> Distinct<T, TComparer>(this Span<T> span, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new(span, new(new(), comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, DistinctOperator<TSource, TOut, TOperator, EqualityComparer<TOut>>> Distinct()
        {
            return new(Source, new(Operator, EqualityComparer<TOut>.Default));
        }

        public SpanEnumerator<TSource, TOut, DistinctOperator<TSource, TOut, TOperator, TComparer>> Distinct<TComparer>(TComparer comparer)
            where TComparer : IEqualityComparer<TOut>
        {
            return new(Source, new(Operator, comparer));
        }
    }

    public struct DistinctOperator<TSpan, TIn, TOperator, TComparer> : ISpanOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IEqualityComparer<TIn>
    {
        internal TOperator Operator;
        internal readonly TComparer Comparer;
        // TODO: it generates CS8714; no way to remove it without #nullable disable
#nullable disable
        internal ArrayPoolDictionary<TIn, byte> Dictionary;
        internal ArrayPoolDictionary<TIn, byte>.Enumerator DictionaryEnumerator;
#nullable restore
        internal int ExistsNull;

        internal DistinctOperator(TOperator op, TComparer comparer)
        {
            Operator = op;
            Comparer = comparer;
            Dictionary = null!;
            DictionaryEnumerator = default;
            ExistsNull = 0;
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
                Dictionary = new ArrayPoolDictionary<TIn, byte>(Comparer);
#nullable restore
                while (true)
                {
                    var current = Operator.TryMoveNext(ref source, out bool ok);
                    if (!ok)
                    {
                        break;
                    }

                    if (current == null)
                    {
                        ExistsNull = 1;
                    }
                    else if (!Dictionary.ContainsKey(current))
                    {
                        Dictionary.Add(current, 0);
                    }
                }

                DictionaryEnumerator = Dictionary.GetEnumerator();
            }

            if (ExistsNull == 1)
            {
                ExistsNull = -1;
                success = true;
                return default!;
            }

            if (DictionaryEnumerator.MoveNext())
            {
                success = true;
                return DictionaryEnumerator.Current.Key;
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