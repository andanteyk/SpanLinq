namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator2<TIn, TSource2, TIn, IntersectByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, EqualityComparer<TKey>>> IntersectBy<TIn, TSource2, TOperator2, TKey>(this ReadOnlySpan<TIn> span, SpanEnumerator<TSource2, TKey, TOperator2> second, Func<TIn, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TKey>
        {
            return new(span, second.Source, new(new(), second.Operator, keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TIn, TKey, TIn, IntersectByOperator<TIn, TKey, TIn, IdentityOperator<TIn>, IdentityOperator<TKey>, TKey, EqualityComparer<TKey>>> IntersectBy<TIn, TKey>(this ReadOnlySpan<TIn> span, ReadOnlySpan<TKey> second, Func<TIn, TKey> keySelector)
        {
            return new(span, second, new(new(), new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TIn, TSource2, TIn, IntersectByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, TComparer>> IntersectBy<TIn, TSource2, TOperator2, TKey, TComparer>(this ReadOnlySpan<TIn> span, SpanEnumerator<TSource2, TKey, TOperator2> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TKey>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second.Source, new(new(), second.Operator, keySelector, comparer));
        }

        public static SpanEnumerator2<TIn, TKey, TIn, IntersectByOperator<TIn, TKey, TIn, IdentityOperator<TIn>, IdentityOperator<TKey>, TKey, TComparer>> IntersectBy<TIn, TKey, TComparer>(this ReadOnlySpan<TIn> span, ReadOnlySpan<TKey> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second, new(new(), new(), keySelector, comparer));
        }


        public static SpanEnumerator2<TIn, TSource2, TIn, IntersectByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, EqualityComparer<TKey>>> IntersectBy<TIn, TSource2, TOperator2, TKey>(this Span<TIn> span, SpanEnumerator<TSource2, TKey, TOperator2> second, Func<TIn, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TKey>
        {
            return new(span, second.Source, new(new(), second.Operator, keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TIn, TKey, TIn, IntersectByOperator<TIn, TKey, TIn, IdentityOperator<TIn>, IdentityOperator<TKey>, TKey, EqualityComparer<TKey>>> IntersectBy<TIn, TKey>(this Span<TIn> span, ReadOnlySpan<TKey> second, Func<TIn, TKey> keySelector)
        {
            return new(span, second, new(new(), new(), keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TIn, TSource2, TIn, IntersectByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, TComparer>> IntersectBy<TIn, TSource2, TOperator2, TKey, TComparer>(this Span<TIn> span, SpanEnumerator<TSource2, TKey, TOperator2> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TKey>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second.Source, new(new(), second.Operator, keySelector, comparer));
        }

        public static SpanEnumerator2<TIn, TKey, TIn, IntersectByOperator<TIn, TKey, TIn, IdentityOperator<TIn>, IdentityOperator<TKey>, TKey, TComparer>> IntersectBy<TIn, TKey, TComparer>(this Span<TIn> span, ReadOnlySpan<TKey> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second, new(new(), new(), keySelector, comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator2<TSource, TSource2, TOut, IntersectByOperator<TSource, TSource2, TOut, TOperator, TOperator2, TKey, EqualityComparer<TKey>>> IntersectBy<TSource2, TOperator2, TKey>(SpanEnumerator<TSource2, TKey, TOperator2> second, Func<TOut, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TKey>
        {
            return new(Source, second.Source, new(Operator, second.Operator, keySelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator2<TSource, TKey, TOut, IntersectByOperator<TSource, TKey, TOut, TOperator, IdentityOperator<TKey>, TKey, EqualityComparer<TKey>>> IntersectBy<TKey>(ReadOnlySpan<TKey> second, Func<TOut, TKey> keySelector)
        {
            return new(Source, second, new(Operator, new IdentityOperator<TKey>(), keySelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator2<TSource, TSource2, TOut, IntersectByOperator<TSource, TSource2, TOut, TOperator, TOperator2, TKey, TComparer>> IntersectBy<TSource2, TOperator2, TKey, TComparer>(SpanEnumerator<TSource2, TKey, TOperator2> second, Func<TOut, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TKey>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, second.Source, new(Operator, second.Operator, keySelector, comparer));
        }

        public SpanEnumerator2<TSource, TKey, TOut, IntersectByOperator<TSource, TKey, TOut, TOperator, IdentityOperator<TKey>, TKey, TComparer>> IntersectBy<TKey, TComparer>(ReadOnlySpan<TKey> second, Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, second, new(Operator, new IdentityOperator<TKey>(), keySelector, comparer));
        }
    }

    public struct IntersectByOperator<TSpan1, TSpan2, TIn, TOperator1, TOperator2, TKey, TComparer> : ISpanOperator2<TSpan1, TSpan2, TIn>, IDisposable
        where TOperator1 : ISpanOperator<TSpan1, TIn>
        where TOperator2 : ISpanOperator<TSpan2, TKey>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal Func<TIn, TKey> KeySelector;
        internal readonly TComparer Comparer;

        internal ArrayPoolDictionary<TKey, Unit>? Dictionary;
        internal bool Initialized;

        internal IntersectByOperator(TOperator1 operator1, TOperator2 operator2, Func<TIn, TKey> keySelector, TComparer comparer)
        {
            Operator1 = operator1;
            Operator2 = operator2;
            KeySelector = keySelector;
            Comparer = comparer;

            Dictionary = null;
            Initialized = false;
        }

        public void Dispose()
        {
            if (Dictionary != null)
            {
                ObjectPool.SharedReturn(Dictionary);
                Dictionary = null;
            }
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan1> source1, ReadOnlySpan<TSpan2> source2, out int length)
        {
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan1> source1, ref ReadOnlySpan<TSpan2> source2, out bool success)
        {
            bool ok;

            if (!Initialized)
            {
                Dictionary = ObjectPool.SharedRent<ArrayPoolDictionary<TKey, Unit>>();
                Dictionary.ClearAndSetComparer(Comparer);

                while (true)
                {
                    var current2 = Operator2.TryMoveNext(ref source2, out ok);
                    if (!ok)
                    {
                        break;
                    }

                    Dictionary[current2] = default;
                }

                Initialized = true;
            }

            while (true)
            {
                var current1 = Operator1.TryMoveNext(ref source1, out ok);
                if (!ok)
                {
                    Dispose();
                    success = false;
                    return default!;
                }

                var current1Key = KeySelector(current1);
                if (Dictionary!.Remove(current1Key))
                {
                    success = true;
                    return current1;
                }
            }
        }
    }
}
