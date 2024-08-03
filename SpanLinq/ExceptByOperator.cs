using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, Convert2Operator<T, TKey, T, ExceptByOperator<T, TKey, T, IdentityOperator<T>, IdentityOperator<TKey>, TKey, EqualityComparer<TKey>>>> ExceptBy<T, TKey>(this ReadOnlySpan<T> first, ReadOnlySpan<TKey> second, Func<T, TKey> keySelector)
        {
            return new(first, new(new(new(), new(), keySelector, EqualityComparer<TKey>.Default), second));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, TKey, T, ExceptByOperator<T, TKey, T, IdentityOperator<T>, IdentityOperator<TKey>, TKey, TComparer>>> ExceptBy<T, TKey, TComparer>(this ReadOnlySpan<T> first, ReadOnlySpan<TKey> second, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(first, new(new(new(), new(), keySelector, comparer), second));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, TSource2, T, ExceptByOperator<T, TSource2, T, IdentityOperator<T>, TOperator2, TKey, EqualityComparer<TKey>>>> ExceptBy<T, TSource2, TOperator2, TKey>(this ReadOnlySpan<T> first, SpanEnumerator<TSource2, TKey, TOperator2> second, Func<T, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TKey>
        {
            return new(first, new(new(new(), second.Operator, keySelector, EqualityComparer<TKey>.Default), second.Source));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, TSource2, T, ExceptByOperator<T, TSource2, T, IdentityOperator<T>, TOperator2, TKey, TComparer>>> ExceptBy<T, TSource2, TOperator2, TKey, TComparer>(this ReadOnlySpan<T> first, SpanEnumerator<TSource2, TKey, TOperator2> second, Func<T, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TKey>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(first, new(new(new(), second.Operator, keySelector, comparer), second.Source));
        }


        public static SpanEnumerator<T, T, Convert2Operator<T, TKey, T, ExceptByOperator<T, TKey, T, IdentityOperator<T>, IdentityOperator<TKey>, TKey, EqualityComparer<TKey>>>> ExceptBy<T, TKey>(this Span<T> first, ReadOnlySpan<TKey> second, Func<T, TKey> keySelector)
        {
            return new(first, new(new(new(), new(), keySelector, EqualityComparer<TKey>.Default), second));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, TKey, T, ExceptByOperator<T, TKey, T, IdentityOperator<T>, IdentityOperator<TKey>, TKey, TComparer>>> ExceptBy<T, TKey, TComparer>(this Span<T> first, ReadOnlySpan<TKey> second, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(first, new(new(new(), new(), keySelector, comparer), second));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, TSource2, T, ExceptByOperator<T, TSource2, T, IdentityOperator<T>, TOperator2, TKey, EqualityComparer<TKey>>>> ExceptBy<T, TSource2, TOperator2, TKey>(this Span<T> first, SpanEnumerator<TSource2, TKey, TOperator2> second, Func<T, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TKey>
        {
            return new(first, new(new(new(), second.Operator, keySelector, EqualityComparer<TKey>.Default), second.Source));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, TSource2, T, ExceptByOperator<T, TSource2, T, IdentityOperator<T>, TOperator2, TKey, TComparer>>> ExceptBy<T, TSource2, TOperator2, TKey, TComparer>(this Span<T> first, SpanEnumerator<TSource2, TKey, TOperator2> second, Func<T, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TKey>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(first, new(new(new(), second.Operator, keySelector, comparer), second.Source));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TKey, TOut, ExceptByOperator<TSource, TKey, TOut, TOperator, IdentityOperator<TKey>, TKey, EqualityComparer<TKey>>>> ExceptBy<TKey>(ReadOnlySpan<TKey> second, Func<TOut, TKey> keySelector)
        {
            return new(Source, new(new(Operator, new(), keySelector, EqualityComparer<TKey>.Default), second));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TKey, TOut, ExceptByOperator<TSource, TKey, TOut, TOperator, IdentityOperator<TKey>, TKey, TComparer>>> ExceptBy<TKey, TComparer>(ReadOnlySpan<TKey> second, Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(new(Operator, new(), keySelector, comparer), second));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TSource2, TOut, ExceptByOperator<TSource, TSource2, TOut, TOperator, TOperator2, TKey, EqualityComparer<TKey>>>> ExceptBy<TSource2, TOperator2, TKey>(SpanEnumerator<TSource2, TKey, TOperator2> second, Func<TOut, TKey> keySelector)
            where TOperator2 : ISpanOperator<TSource2, TKey>
        {
            return new(Source, new(new(Operator, second.Operator, keySelector, EqualityComparer<TKey>.Default), second.Source));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TSource2, TOut, ExceptByOperator<TSource, TSource2, TOut, TOperator, TOperator2, TKey, TComparer>>> ExceptBy<TSource2, TOperator2, TKey, TComparer>(SpanEnumerator<TSource2, TKey, TOperator2> second, Func<TOut, TKey> keySelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TKey>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(new(Operator, second.Operator, keySelector, comparer), second.Source));
        }
    }


    public struct ExceptByOperator<TSpan1, TSpan2, TIn, TOperator1, TOperator2, TKey, TComparer> : ISpanOperator2<TSpan1, TSpan2, TIn>, IDisposable
        where TOperator1 : ISpanOperator<TSpan1, TIn>
        where TOperator2 : ISpanOperator<TSpan2, TKey>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal Func<TIn, TKey> KeySelector;
        internal TComparer Comparer;

        internal ArrayPoolDictionary<TKey, Unit>? Dictionary;

        internal ExceptByOperator(TOperator1 op1, TOperator2 op2, Func<TIn, TKey> keySelector, TComparer comparer)
        {
            Operator1 = op1;
            Operator2 = op2;
            Comparer = comparer;
            KeySelector = keySelector;

            Dictionary = null;
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
            if (Dictionary == null)
            {
                Dictionary = ObjectPool.SharedRent<ArrayPoolDictionary<TKey, Unit>>();
                Dictionary.ClearAndSetComparer(Comparer);

                while (true)
                {
                    var current2 = Operator2.TryMoveNext(ref source2, out bool ok);
                    if (!ok)
                    {
                        break;
                    }

                    Dictionary[current2] = default;
                }
            }

            while (true)
            {
                var current1 = Operator1.TryMoveNext(ref source1, out bool ok);
                if (!ok)
                {
                    Dispose();
                    success = false;
                    return default!;
                }

                var current1Key = KeySelector(current1);
                if (Dictionary.TryAdd(current1Key, default))
                {
                    success = true;
                    return current1;
                }
            }
        }
    }
}
