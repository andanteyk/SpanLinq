namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TIn, TIn, IntersectOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, EqualityComparer<TIn>>>> Intersect<TIn>(this ReadOnlySpan<TIn> first, ReadOnlySpan<TIn> second)
        {
            return new(first, new(new(new(), new(), EqualityComparer<TIn>.Default), second));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TIn, TIn, IntersectOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TComparer>>> Intersect<TIn, TComparer>(this ReadOnlySpan<TIn> first, ReadOnlySpan<TIn> second, TComparer comparer)
            where TComparer : IEqualityComparer<TIn>
        {
            return new(first, new(new(new(), new(), comparer), second));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TSource2, TIn, IntersectOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, EqualityComparer<TIn>>>> Intersect<TIn, TSource2, TOperator2>(this ReadOnlySpan<TIn> first, SpanEnumerator<TSource2, TIn, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TIn>
        {
            return new(first, new(new(new(), second.Operator, EqualityComparer<TIn>.Default), second.Source));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TSource2, TIn, IntersectOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TComparer>>> Intersect<TIn, TSource2, TOperator2, TComparer>(this ReadOnlySpan<TIn> first, SpanEnumerator<TSource2, TIn, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TIn>
            where TComparer : IEqualityComparer<TIn>
        {
            return new(first, new(new(new(), second.Operator, comparer), second.Source));
        }


        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TIn, TIn, IntersectOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, EqualityComparer<TIn>>>> Intersect<TIn>(this Span<TIn> first, ReadOnlySpan<TIn> second)
        {
            return new(first, new(new(new(), new(), EqualityComparer<TIn>.Default), second));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TIn, TIn, IntersectOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TComparer>>> Intersect<TIn, TComparer>(this Span<TIn> first, ReadOnlySpan<TIn> second, TComparer comparer)
            where TComparer : IEqualityComparer<TIn>
        {
            return new(first, new(new(new(), new(), comparer), second));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TSource2, TIn, IntersectOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, EqualityComparer<TIn>>>> Intersect<TIn, TSource2, TOperator2>(this Span<TIn> first, SpanEnumerator<TSource2, TIn, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TIn>
        {
            return new(first, new(new(new(), second.Operator, EqualityComparer<TIn>.Default), second.Source));
        }

        public static SpanEnumerator<TIn, TIn, Convert2Operator<TIn, TSource2, TIn, IntersectOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TComparer>>> Intersect<TIn, TSource2, TOperator2, TComparer>(this Span<TIn> first, SpanEnumerator<TSource2, TIn, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TIn>
            where TComparer : IEqualityComparer<TIn>
        {
            return new(first, new(new(new(), second.Operator, comparer), second.Source));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TOut, TOut, IntersectOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>, EqualityComparer<TOut>>>> Intersect(ReadOnlySpan<TOut> second)
        {
            return new(Source, new(new(Operator, new(), EqualityComparer<TOut>.Default), second));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TOut, TOut, IntersectOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>, TComparer>>> Intersect<TComparer>(ReadOnlySpan<TOut> second, TComparer comparer)
            where TComparer : IEqualityComparer<TOut>
        {
            return new(Source, new(new(Operator, new(), comparer), second));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TSource2, TOut, IntersectOperator<TSource, TSource2, TOut, TOperator, TOperator2, EqualityComparer<TOut>>>> Intersect<TSource2, TOperator2>(SpanEnumerator<TSource2, TOut, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TOut>
        {
            return new(Source, new(new(Operator, second.Operator, EqualityComparer<TOut>.Default), second.Source));
        }

        public SpanEnumerator<TSource, TOut, Convert2Operator<TSource, TSource2, TOut, IntersectOperator<TSource, TSource2, TOut, TOperator, TOperator2, TComparer>>> Intersect<TSource2, TOperator2, TComparer>(SpanEnumerator<TSource2, TOut, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TOut>
            where TComparer : IEqualityComparer<TOut>
        {
            return new(Source, new(new(Operator, second.Operator, comparer), second.Source));
        }
    }

    public struct IntersectOperator<TSpan1, TSpan2, TIn, TOperator1, TOperator2, TComparer> : ISpanOperator2<TSpan1, TSpan2, TIn>, IDisposable
        where TOperator1 : ISpanOperator<TSpan1, TIn>
        where TOperator2 : ISpanOperator<TSpan2, TIn>
        where TComparer : IEqualityComparer<TIn>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal readonly TComparer Comparer;

        internal ArrayPoolDictionary<TIn, Unit>? Dictionary;
        internal bool Initialized;

        internal IntersectOperator(TOperator1 operator1, TOperator2 operator2, TComparer comparer)
        {
            Operator1 = operator1;
            Operator2 = operator2;
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
                Dictionary = ObjectPool.SharedRent<ArrayPoolDictionary<TIn, Unit>>();
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

                if (Dictionary!.Remove(current1))
                {
                    success = true;
                    return current1;
                }
            }
        }
    }
}
