namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator2<T, TSecond, T, ConcatOperator<T, TSecond, T, IdentityOperator<T>, TSecondOperator>> Concat<T, TSecond, TSecondOperator>(this ReadOnlySpan<T> span, SpanEnumerator<TSecond, T, TSecondOperator> second)
            where TSecondOperator : ISpanOperator<TSecond, T>
        {
            return new(span, second.Source, new(new(), second.Operator));
        }

        public static SpanEnumerator2<T, T, T, ConcatOperator<T, T, T, IdentityOperator<T>, IdentityOperator<T>>> Concat<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> second)
        {
            return new(span, second, new(new(), new()));
        }

        public static SpanEnumerator2<T, TSecond, T, ConcatOperator<T, TSecond, T, IdentityOperator<T>, TSecondOperator>> Concat<T, TSecond, TSecondOperator>(this Span<T> span, SpanEnumerator<TSecond, T, TSecondOperator> second)
            where TSecondOperator : ISpanOperator<TSecond, T>
        {
            return new(span, second.Source, new(new(), second.Operator));
        }

        public static SpanEnumerator2<T, T, T, ConcatOperator<T, T, T, IdentityOperator<T>, IdentityOperator<T>>> Concat<T>(this Span<T> span, ReadOnlySpan<T> second)
        {
            return new(span, second, new(new(), new()));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator2<TSource, TSource2, TOut, ConcatOperator<TSource, TSource2, TOut, TOperator, TOperator2>> Concat<TSource2, TOperator2>(SpanEnumerator<TSource2, TOut, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TOut>
        {
            return new(Source, second.Source, new(Operator, second.Operator));
        }

        public SpanEnumerator2<TSource, TOut, TOut, ConcatOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>>> Concat(ReadOnlySpan<TOut> second)
        {
            return new(Source, second, new(Operator, new IdentityOperator<TOut>()));
        }
    }

    public struct ConcatOperator<TSpan1, TSpan2, TIn, TOperator1, TOperator2> : ISpanOperator2<TSpan1, TSpan2, TIn>
        where TOperator1 : ISpanOperator<TSpan1, TIn>
        where TOperator2 : ISpanOperator<TSpan2, TIn>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;

        internal ConcatOperator(TOperator1 operator1, TOperator2 operator2)
        {
            Operator1 = operator1;
            Operator2 = operator2;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan1> source1, ReadOnlySpan<TSpan2> source2, out int length)
        {
            if (Operator1.TryGetNonEnumeratedCount(source1, out int length1) && Operator2.TryGetNonEnumeratedCount(source2, out int length2))
            {
                length = length1 + length2;
                return true;
            }
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan1> source1, ref ReadOnlySpan<TSpan2> source2, out bool success)
        {
            var current1 = Operator1.TryMoveNext(ref source1, out bool ok);
            if (ok)
            {
                success = true;
                return current1;
            }

            var current2 = Operator2.TryMoveNext(ref source2, out ok);
            if (ok)
            {
                success = true;
                return current2;
            }

            success = false;
            return default!;
        }
    }
}
