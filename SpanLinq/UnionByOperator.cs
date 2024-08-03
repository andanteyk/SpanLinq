namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TIn, TIn, UnionByOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TKey, EqualityComparer<TKey>>>> UnionBy<TIn, TKey>(this ReadOnlySpan<TIn> first, ReadOnlySpan<TIn> second, Func<TIn, TKey> keySelector)
        {
            return new(first, new(new(new(), new(), keySelector, EqualityComparer<TKey>.Default), second));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TIn, TIn, UnionByOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TKey, TComparer>>> UnionBy<TIn, TKey, TComparer>(this ReadOnlySpan<TIn> first, ReadOnlySpan<TIn> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(first, new(new(new(), new(), keySelector, comparer), second));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TSource2, TIn, UnionByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, EqualityComparer<TKey>>>> UnionBy<TIn, TSource2, TOperator2, TKey>(this ReadOnlySpan<TIn> first, SpanEnumerator<TSource2, TIn, TOperator2> second, Func<TIn, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TIn>
        {
            return new(first, new(new(new(), second.Operator, keySelector, EqualityComparer<TKey>.Default), second.Source));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TSource2, TIn, UnionByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, TComparer>>> UnionBy<TIn, TSource2, TOperator2, TKey, TComparer>(this ReadOnlySpan<TIn> first, SpanEnumerator<TSource2, TIn, TOperator2> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TIn>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(first, new(new(new(), second.Operator, keySelector, comparer), second.Source));
        }


        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TIn, TIn, UnionByOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TKey, EqualityComparer<TKey>>>> UnionBy<TIn, TKey>(this Span<TIn> first, ReadOnlySpan<TIn> second, Func<TIn, TKey> keySelector)
        {
            return new(first, new(new(new(), new(), keySelector, EqualityComparer<TKey>.Default), second));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TIn, TIn, UnionByOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TKey, TComparer>>> UnionBy<TIn, TKey, TComparer>(this Span<TIn> first, ReadOnlySpan<TIn> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(first, new(new(new(), new(), keySelector, comparer), second));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TSource2, TIn, UnionByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, EqualityComparer<TKey>>>> UnionBy<TIn, TSource2, TOperator2, TKey>(this Span<TIn> first, SpanEnumerator<TSource2, TIn, TOperator2> second, Func<TIn, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TIn>
        {
            return new(first, new(new(new(), second.Operator, keySelector, EqualityComparer<TKey>.Default), second.Source));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TSource2, TIn, UnionByOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TKey, TComparer>>> UnionBy<TIn, TSource2, TOperator2, TKey, TComparer>(this Span<TIn> first, SpanEnumerator<TSource2, TIn, TOperator2> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TIn>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(first, new(new(new(), second.Operator, keySelector, comparer), second.Source));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TOut, TOut, UnionByOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>, TKey, EqualityComparer<TKey>>>> UnionBy<TKey>(ReadOnlySpan<TOut> second, Func<TOut, TKey> keySelector)
        {
            return new(Source, new(new(Operator, new(), keySelector, EqualityComparer<TKey>.Default), second));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TOut, TOut, UnionByOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>, TKey, TComparer>>> UnionBy<TKey, TComparer>(ReadOnlySpan<TOut> second, Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(new(Operator, new(), keySelector, comparer), second));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TSource2, TOut, UnionByOperator<TSource, TSource2, TOut, TOperator, TOperator2, TKey, EqualityComparer<TKey>>>> UnionBy<TSource2, TOperator2, TKey>(SpanEnumerator<TSource2, TOut, TOperator2> second, Func<TOut, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TOut>
        {
            return new(Source, new(new(Operator, second.Operator, keySelector, EqualityComparer<TKey>.Default), second.Source));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TSource2, TOut, UnionByOperator<TSource, TSource2, TOut, TOperator, TOperator2, TKey, TComparer>>> UnionBy<TSource2, TOperator2, TKey, TComparer>(SpanEnumerator<TSource2, TOut, TOperator2> second, Func<TOut, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TOut>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(new(Operator, second.Operator, keySelector, comparer), second.Source));
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
        internal ArrayPoolDictionary<TKey, Unit>? Dictionary;
        internal bool Initialized;

        internal UnionByOperator(TOperator1 operator1, TOperator2 operator2, Func<TIn, TKey> keySelector, TComparer comparer)
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
                Initialized = true;
            }

            do
            {
                var current1 = Operator1.TryMoveNext(ref source1, out ok);
                if (ok)
                {
                    var key = KeySelector(current1);

                    if (!Dictionary!.TryGetValue(key, out _))
                    {
                        Dictionary.Add(key, default);
                        success = true;
                        return current1;
                    }
                }
            } while (ok);

            do
            {
                var current2 = Operator2.TryMoveNext(ref source2, out ok);
                if (ok)
                {
                    var key = KeySelector(current2);

                    if (!Dictionary!.TryGetValue(key, out _))
                    {
                        Dictionary.Add(key, default);
                        success = true;
                        return current2;
                    }
                }
            } while (ok);

            Dispose();
            success = false;
            return default!;
        }
    }
}
