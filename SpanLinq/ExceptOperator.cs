namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, Convert2Operator<T, T, T, ExceptOperator<T, T, T, IdentityOperator<T>, IdentityOperator<T>, EqualityComparer<T>>>> Except<T>(this ReadOnlySpan<T> first, ReadOnlySpan<T> second)
        {
            return new(first, new(new(new(), new(), EqualityComparer<T>.Default), second));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, T, T, ExceptOperator<T, T, T, IdentityOperator<T>, IdentityOperator<T>, TComparer>>> Except<T, TComparer>(this ReadOnlySpan<T> first, ReadOnlySpan<T> second, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new(first, new(new(new(), new(), comparer), second));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, TSource2, T, ExceptOperator<T, TSource2, T, IdentityOperator<T>, TOperator2, EqualityComparer<T>>>> Except<T, TSource2, TOperator2>(this ReadOnlySpan<T> first, SpanEnumerator<TSource2, T, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, T>
        {
            return new(first, new(new(new(), second.Operator, EqualityComparer<T>.Default), second.Source));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, TSource2, T, ExceptOperator<T, TSource2, T, IdentityOperator<T>, TOperator2, TComparer>>> Except<T, TSource2, TOperator2, TComparer>(this ReadOnlySpan<T> first, SpanEnumerator<TSource2, T, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, T>
            where TComparer : IEqualityComparer<T>
        {
            return new(first, new(new(new(), second.Operator, comparer), second.Source));
        }


        public static SpanEnumerator<T, T, Convert2Operator<T, T, T, ExceptOperator<T, T, T, IdentityOperator<T>, IdentityOperator<T>, EqualityComparer<T>>>> Except<T>(this Span<T> first, ReadOnlySpan<T> second)
        {
            return new(first, new(new(new(), new(), EqualityComparer<T>.Default), second));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, T, T, ExceptOperator<T, T, T, IdentityOperator<T>, IdentityOperator<T>, TComparer>>> Except<T, TComparer>(this Span<T> first, ReadOnlySpan<T> second, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new(first, new(new(new(), new(), comparer), second));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, TSource2, T, ExceptOperator<T, TSource2, T, IdentityOperator<T>, TOperator2, EqualityComparer<T>>>> Except<T, TSource2, TOperator2>(this Span<T> first, SpanEnumerator<TSource2, T, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, T>
        {
            return new(first, new(new(new(), second.Operator, EqualityComparer<T>.Default), second.Source));
        }

        public static SpanEnumerator<T, T, Convert2Operator<T, TSource2, T, ExceptOperator<T, TSource2, T, IdentityOperator<T>, TOperator2, TComparer>>> Except<T, TSource2, TOperator2, TComparer>(this Span<T> first, SpanEnumerator<TSource2, T, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, T>
            where TComparer : IEqualityComparer<T>
        {
            return new(first, new(new(new(), second.Operator, comparer), second.Source));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TOut, TOut, ExceptOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>, EqualityComparer<TOut>>>> Except(ReadOnlySpan<TOut> second)
        {
            return new(Source, new(new(Operator, new(), EqualityComparer<TOut>.Default), second));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TOut, TOut, ExceptOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>, TComparer>>> Except<TComparer>(ReadOnlySpan<TOut> second, TComparer comparer)
            where TComparer : IEqualityComparer<TOut>
        {
            return new(Source, new(new(Operator, new(), comparer), second));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TSource2, TOut, ExceptOperator<TSource, TSource2, TOut, TOperator, TOperator2, EqualityComparer<TOut>>>> Except<TSource2, TOperator2>(SpanEnumerator<TSource2, TOut, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TOut>
        {
            return new(Source, new(new(Operator, second.Operator, EqualityComparer<TOut>.Default), second.Source));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TSource2, TOut, ExceptOperator<TSource, TSource2, TOut, TOperator, TOperator2, TComparer>>> Except<TSource2, TOperator2, TComparer>(SpanEnumerator<TSource2, TOut, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TOut>
            where TComparer : IEqualityComparer<TOut>
        {
            return new(Source, new(new(Operator, second.Operator, comparer), second.Source));
        }
    }

    public struct ExceptOperator<TSpan1, TSpan2, TIn, TOperator1, TOperator2, TComparer> : ISpanOperator2<TSpan1, TSpan2, TIn>, IDisposable
        where TOperator1 : ISpanOperator<TSpan1, TIn>
        where TOperator2 : ISpanOperator<TSpan2, TIn>
        where TComparer : IEqualityComparer<TIn>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal TComparer Comparer;

        internal ArrayPoolDictionary<TIn, Unit>? Dictionary;

        internal ExceptOperator(TOperator1 op1, TOperator2 op2, TComparer comparer)
        {
            Operator1 = op1;
            Operator2 = op2;
            Comparer = comparer;

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
                Dictionary = ObjectPool.SharedRent<ArrayPoolDictionary<TIn, Unit>>();
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
                    break;
                }

                if (Dictionary.TryAdd(current1, default))
                {
                    success = true;
                    return current1;
                }
            }

            success = false;
            return default!;
        }
    }
}
