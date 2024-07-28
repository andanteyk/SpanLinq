using System.ComponentModel.Design;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator2<TIn, TSource2, TIn, UnionByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, EqualityComparer<TKey>>> UnionBy<TIn, TSource2, TOperator2, TKey>(this ReadOnlySpan<TIn> span, SpanEnumerator<TSource2, TIn, TOperator2> second, Func<TIn, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TIn>
        {
            return new(span, second.Source, new(new(), second.Operator, keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TIn, TIn, TIn, UnionByOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TKey, EqualityComparer<TKey>>> UnionBy<TIn, TKey>(this ReadOnlySpan<TIn> span, ReadOnlySpan<TIn> second, Func<TIn, TKey> keySelector)
        {
            return new(span, second, new(new(), new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TIn, TSource2, TIn, UnionByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, TComparer>> UnionBy<TIn, TSource2, TOperator2, TKey, TComparer>(this ReadOnlySpan<TIn> span, SpanEnumerator<TSource2, TIn, TOperator2> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TIn>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second.Source, new(new(), second.Operator, keySelector, comparer));
        }

        public static SpanEnumerator2<TIn, TIn, TIn, UnionByOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TKey, TComparer>> UnionBy<TIn, TKey, TComparer>(this ReadOnlySpan<TIn> span, ReadOnlySpan<TIn> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second, new(new(), new(), keySelector, comparer));
        }


        public static SpanEnumerator2<TIn, TSource2, TIn, UnionByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, EqualityComparer<TKey>>> UnionBy<TIn, TSource2, TOperator2, TKey>(this Span<TIn> span, SpanEnumerator<TSource2, TIn, TOperator2> second, Func<TIn, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TIn>
        {
            return new(span, second.Source, new(new(), second.Operator, keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TIn, TIn, TIn, UnionByOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TKey, EqualityComparer<TKey>>> UnionBy<TIn, TKey>(this Span<TIn> span, ReadOnlySpan<TIn> second, Func<TIn, TKey> keySelector)
        {
            return new(span, second, new(new(), new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TIn, TSource2, TIn, UnionByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, TComparer>> UnionBy<TIn, TSource2, TOperator2, TKey, TComparer>(this Span<TIn> span, SpanEnumerator<TSource2, TIn, TOperator2> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TIn>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second.Source, new(new(), second.Operator, keySelector, comparer));
        }

        public static SpanEnumerator2<TIn, TIn, TIn, UnionByOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TKey, TComparer>> UnionBy<TIn, TKey, TComparer>(this Span<TIn> span, ReadOnlySpan<TIn> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second, new(new(), new(), keySelector, comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator2<TSource, TSource2, TOut, UnionByOperator<TSource, TSource2, TOut, TOperator, TOperator2, TKey, EqualityComparer<TKey>>> UnionBy<TSource2, TOperator2, TKey>(SpanEnumerator<TSource2, TOut, TOperator2> second, Func<TOut, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TOut>
        {
            return new(Source, second.Source, new(Operator, second.Operator, keySelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator2<TSource, TOut, TOut, UnionByOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>, TKey, EqualityComparer<TKey>>> UnionBy<TKey>(ReadOnlySpan<TOut> second, Func<TOut, TKey> keySelector)
        {
            return new(Source, second, new(Operator, new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator2<TSource, TSource2, TOut, UnionByOperator<TSource, TSource2, TOut, TOperator, TOperator2, TKey, TComparer>> UnionBy<TSource2, TOperator2, TKey, TComparer>(SpanEnumerator<TSource2, TOut, TOperator2> second, Func<TOut, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TOut>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, second.Source, new(Operator, second.Operator, keySelector, comparer));
        }

        public SpanEnumerator2<TSource, TOut, TOut, UnionByOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>, TKey, TComparer>> UnionBy<TKey, TComparer>(ReadOnlySpan<TOut> second, Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, second, new(Operator, new(), keySelector, comparer));
        }
    }

    public struct UnionByOperator<TSpan1, TSpan2, TIn, TOperator1, TOperator2, TKey, TComparer> : ISpanOperator2<TSpan1, TSpan2, TIn>, IDisposable
        where TOperator1 : ISpanOperator<TSpan1, TIn>
        where TOperator2 : ISpanOperator<TSpan2, TIn>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal Func<TIn, TKey> KeySelector;
        internal readonly TComparer Comparer;
        internal ArrayPoolDictionary<TKey, byte>? Dictionary;
        internal bool ExistsNull;

        internal UnionByOperator(TOperator1 operator1, TOperator2 operator2, Func<TIn, TKey> keySelector, TComparer comparer)
        {
            Operator1 = operator1;
            Operator2 = operator2;
            KeySelector = keySelector;
            Comparer = comparer;
            Dictionary = null;
            ExistsNull = false;
        }

        public void Dispose()
        {
            Dictionary?.Dispose();
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan1> source1, ReadOnlySpan<TSpan2> source2, out int length)
        {
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan1> source1, ref ReadOnlySpan<TSpan2> source2, out bool success)
        {
            bool ok;

            if (Dictionary == null)
            {
                Dictionary = new(Comparer);
            }

            do
            {
                var current1 = Operator1.TryMoveNext(ref source1, out ok);
                if (ok)
                {
                    var key = KeySelector(current1);

                    if (key == null)
                    {
                        if (!ExistsNull)
                        {
                            ExistsNull = true;
                            success = true;
                            return current1;
                        }
                    }
                    else
                    {
                        if (!Dictionary.TryGetValue(key, out _))
                        {
                            Dictionary.Add(key, default);
                            success = true;
                            return current1;
                        }
                    }
                }
            } while (ok);

            do
            {
                var current2 = Operator2.TryMoveNext(ref source2, out ok);
                if (ok)
                {
                    var key = KeySelector(current2);

                    if (key == null)
                    {
                        if (!ExistsNull)
                        {
                            ExistsNull = true;
                            success = true;
                            return current2;
                        }
                    }
                    else
                    {
                        if (!Dictionary.TryGetValue(key, out _))
                        {
                            Dictionary.Add(key, default);
                            success = true;
                            return current2;
                        }
                    }
                }
            } while (ok);


            success = false;
            return default!;
        }
    }
}
