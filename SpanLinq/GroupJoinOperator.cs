namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TSource1, TSource2, TKey, TResult, EqualityComparer<TKey>>>> GroupJoin<TSource1, TSource2, TKey, TResult>(this ReadOnlySpan<TSource1> outer, ReadOnlySpan<TSource2> inner, Func<TSource1, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TSource1, IEnumerable<TSource2>, TResult> resultSelector)
        {
            return new(outer, new(new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default), inner));
        }

        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TSource1, TSource2, TKey, TResult, TComparer>>> GroupJoin<TSource1, TSource2, TKey, TResult, TComparer>(this ReadOnlySpan<TSource1> outer, ReadOnlySpan<TSource2> inner, Func<TSource1, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TSource1, IEnumerable<TSource2>, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(outer, new(new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, comparer), inner));
        }

        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, TOperator2, TSource1, TInner, TKey, TResult, EqualityComparer<TKey>>>> GroupJoin<TSource1, TSource2, TOperator2, TInner, TKey, TResult>(this ReadOnlySpan<TSource1> outer, SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TSource1, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource1, IEnumerable<TInner>, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TInner>
        {
            return new(outer, new(new(new(), inner.Operator, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default), inner.Source));
        }

        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, TOperator2, TSource1, TInner, TKey, TResult, TComparer>>> GroupJoin<TSource1, TSource2, TOperator2, TInner, TKey, TResult, TComparer>(this ReadOnlySpan<TSource1> outer, SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TSource1, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource1, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(outer, new(new(new(), inner.Operator, outerKeySelector, innerKeySelector, resultSelector, comparer), inner.Source));
        }


        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TSource1, TSource2, TKey, TResult, EqualityComparer<TKey>>>> GroupJoin<TSource1, TSource2, TKey, TResult>(this Span<TSource1> outer, ReadOnlySpan<TSource2> inner, Func<TSource1, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TSource1, IEnumerable<TSource2>, TResult> resultSelector)
        {
            return new(outer, new(new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default), inner));
        }

        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TSource1, TSource2, TKey, TResult, TComparer>>> GroupJoin<TSource1, TSource2, TKey, TResult, TComparer>(this Span<TSource1> outer, ReadOnlySpan<TSource2> inner, Func<TSource1, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TSource1, IEnumerable<TSource2>, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(outer, new(new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, comparer), inner));
        }

        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, TOperator2, TSource1, TInner, TKey, TResult, EqualityComparer<TKey>>>> GroupJoin<TSource1, TSource2, TOperator2, TInner, TKey, TResult>(this Span<TSource1> outer, SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TSource1, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource1, IEnumerable<TInner>, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TInner>
        {
            return new(outer, new(new(new(), inner.Operator, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default), inner.Source));
        }

        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, TOperator2, TSource1, TInner, TKey, TResult, TComparer>>> GroupJoin<TSource1, TSource2, TOperator2, TInner, TKey, TResult, TComparer>(this Span<TSource1> outer, SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TSource1, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource1, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(outer, new(new(new(), inner.Operator, outerKeySelector, innerKeySelector, resultSelector, comparer), inner.Source));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TResult, Convert2Operator<TSource, TSource2, TResult, GroupJoinOperator<TSource, TSource2, TOperator, IdentityOperator<TSource2>, TOut, TSource2, TKey, TResult, EqualityComparer<TKey>>>> GroupJoin<TSource2, TKey, TResult>(ReadOnlySpan<TSource2> inner, Func<TOut, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TOut, IEnumerable<TSource2>, TResult> resultSelector)
        {
            return new(Source, new(new(Operator, new(), outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default), inner));
        }

        public SpanEnumerator<TSource, TResult, Convert2Operator<TSource, TSource2, TResult, GroupJoinOperator<TSource, TSource2, TOperator, IdentityOperator<TSource2>, TOut, TSource2, TKey, TResult, TComparer>>> GroupJoin<TSource2, TKey, TResult, TComparer>(ReadOnlySpan<TSource2> inner, Func<TOut, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TOut, IEnumerable<TSource2>, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(new(Operator, new(), outerKeySelector, innerKeySelector, resultSelector, comparer), inner));
        }

        public SpanEnumerator<TSource, TResult, Convert2Operator<TSource, TSource2, TResult, GroupJoinOperator<TSource, TSource2, TOperator, TOperator2, TOut, TInner, TKey, TResult, EqualityComparer<TKey>>>> GroupJoin<TSource2, TOperator2, TInner, TKey, TResult>(SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, IEnumerable<TInner>, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TInner>
        {
            return new(Source, new(new(Operator, inner.Operator, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default), inner.Source));
        }

        public SpanEnumerator<TSource, TResult, Convert2Operator<TSource, TSource2, TResult, GroupJoinOperator<TSource, TSource2, TOperator, TOperator2, TOut, TInner, TKey, TResult, TComparer>>> GroupJoin<TSource2, TOperator2, TInner, TKey, TResult, TComparer>(SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(new(Operator, inner.Operator, outerKeySelector, innerKeySelector, resultSelector, comparer), inner.Source));
        }
    }

    public struct GroupJoinOperator<TSpan1, TSpan2, TOperator1, TOperator2, TOuter, TInner, TKey, TResult, TComparer> : ISpanOperator2<TSpan1, TSpan2, TResult>, IDisposable
        where TOperator1 : ISpanOperator<TSpan1, TOuter>
        where TOperator2 : ISpanOperator<TSpan2, TInner>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal readonly Func<TOuter, TKey> OuterKeySelector;
        internal readonly Func<TInner, TKey> InnerKeySelector;
        internal readonly Func<TOuter, IEnumerable<TInner>, TResult> ResultSelector;
        internal readonly TComparer Comparer;

        internal ArrayPoolDictionary<TKey, ArrayPoolList<TInner>>? Dictionary;
        internal bool Initialized;

        internal GroupJoinOperator(TOperator1 op1, TOperator2 op2, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
        {
            Operator1 = op1;
            Operator2 = op2;
            OuterKeySelector = outerKeySelector;
            InnerKeySelector = innerKeySelector;
            ResultSelector = resultSelector;
            Comparer = comparer;

            Dictionary = null;
            Initialized = false;
        }

        private void CreateDictionary(ref ReadOnlySpan<TSpan2> source2)
        {
            Dictionary = ObjectPool.SharedRent<ArrayPoolDictionary<TKey, ArrayPoolList<TInner>>>();
            Dictionary.ClearAndSetComparer(Comparer);

            while (true)
            {
                var current2 = Operator2.TryMoveNext(ref source2, out bool ok);
                if (!ok)
                {
                    break;
                }

                var current2Key = InnerKeySelector(current2);
                if (Dictionary.TryGetValue(current2Key, out var list))
                {
                    list.Add(current2);
                }
                else
                {
                    list = ObjectPool.SharedRent<ArrayPoolList<TInner>>();
                    list.Clear();
                    list.Add(current2);
                    Dictionary[current2Key] = list;
                }
            }

            Initialized = true;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan1> source1, ReadOnlySpan<TSpan2> source2, out int length)
        {
            return Operator1.TryGetNonEnumeratedCount(source1, out length);
        }

        public TResult TryMoveNext(ref ReadOnlySpan<TSpan1> source1, ref ReadOnlySpan<TSpan2> source2, out bool success)
        {
            if (!Initialized)
            {
                CreateDictionary(ref source2);
            }

            var current1 = Operator1.TryMoveNext(ref source1, out bool ok);
            if (!ok)
            {
                Dispose();
                success = false;
                return default!;
            }

            var current1Key = OuterKeySelector(current1);


            success = true;
            if (Dictionary!.TryGetValue(current1Key, out var list))
            {
                return ResultSelector(current1, list);
            }
            else
            {
                return ResultSelector(current1, Array.Empty<TInner>());
            }
        }

        public void Dispose()
        {
            if (Dictionary != null)
            {
                foreach (var pair in Dictionary)
                {
                    ObjectPool.SharedReturn(pair.Value);
                }
                ObjectPool.SharedReturn(Dictionary);
                Dictionary = null;
            }
        }
    }
}
