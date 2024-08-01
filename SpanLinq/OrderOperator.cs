namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, T, Comparer<T>>> Order<T>(this ReadOnlySpan<T> span)
        {
            return new(span, new(new(), OrderHelper<T>.IdentityFunction, false, Comparer<T>.Default));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, T, TComparer>> Order<T, TComparer>(this ReadOnlySpan<T> span, TComparer comparer)
            where TComparer : IComparer<T>
        {
            return new(span, new(new(), OrderHelper<T>.IdentityFunction, false, comparer));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, T, Comparer<T>>> Order<T>(this Span<T> span)
        {
            return new(span, new(new(), OrderHelper<T>.IdentityFunction, false, Comparer<T>.Default));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, T, TComparer>> Order<T, TComparer>(this Span<T> span, TComparer comparer)
            where TComparer : IComparer<T>
        {
            return new(span, new(new(), OrderHelper<T>.IdentityFunction, false, comparer));
        }



        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, T, Comparer<T>>> OrderDescending<T>(this ReadOnlySpan<T> span)
        {
            return new(span, new(new(), OrderHelper<T>.IdentityFunction, true, Comparer<T>.Default));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, T, TComparer>> OrderDescending<T, TComparer>(this ReadOnlySpan<T> span, TComparer comparer)
            where TComparer : IComparer<T>
        {
            return new(span, new(new(), OrderHelper<T>.IdentityFunction, true, comparer));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, T, Comparer<T>>> OrderDescending<T>(this Span<T> span)
        {
            return new(span, new(new(), OrderHelper<T>.IdentityFunction, true, Comparer<T>.Default));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, T, TComparer>> OrderDescending<T, TComparer>(this Span<T> span, TComparer comparer)
            where TComparer : IComparer<T>
        {
            return new(span, new(new(), OrderHelper<T>.IdentityFunction, true, comparer));
        }

    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, OrderByOperator<TSource, TOut, TOperator, TOut, Comparer<TOut>>> Order()
        {
            return new(Source, new(Operator, OrderHelper<TOut>.IdentityFunction, false, Comparer<TOut>.Default));
        }

        public SpanEnumerator<TSource, TOut, OrderByOperator<TSource, TOut, TOperator, TOut, TComparer>> Order<TComparer>(TComparer comparer)
            where TComparer : IComparer<TOut>
        {
            return new(Source, new(Operator, OrderHelper<TOut>.IdentityFunction, false, comparer));
        }

        public SpanEnumerator<TSource, TOut, OrderByOperator<TSource, TOut, TOperator, TOut, Comparer<TOut>>> OrderDescending()
        {
            return new(Source, new(Operator, OrderHelper<TOut>.IdentityFunction, true, Comparer<TOut>.Default));
        }

        public SpanEnumerator<TSource, TOut, OrderByOperator<TSource, TOut, TOperator, TOut, TComparer>> OrderDescending<TComparer>(TComparer comparer)
            where TComparer : IComparer<TOut>
        {
            return new(Source, new(Operator, OrderHelper<TOut>.IdentityFunction, true, comparer));
        }
    }
}
