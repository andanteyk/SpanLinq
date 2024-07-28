namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static bool SequenceEqual<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> second)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SequenceEqual(new SpanEnumerator<T, T, IdentityOperator<T>>(second, new()), EqualityComparer<T>.Default);
        }

        public static bool SequenceEqual<T, TComparer>(this ReadOnlySpan<T> span, ReadOnlySpan<T> second, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SequenceEqual(new SpanEnumerator<T, T, IdentityOperator<T>>(second, new()), comparer);
        }

        public static bool SequenceEqual<T, TSpan2, TOperator2>(this ReadOnlySpan<T> span, SpanEnumerator<TSpan2, T, TOperator2> second)
            where TOperator2 : ISpanOperator<TSpan2, T>
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SequenceEqual(second, EqualityComparer<T>.Default);
        }

        public static bool SequenceEqual<T, TSpan2, TOperator2, TComparer>(this ReadOnlySpan<T> span, SpanEnumerator<TSpan2, T, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSpan2, T>
            where TComparer : IEqualityComparer<T>
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SequenceEqual(second, comparer);
        }



        public static bool SequenceEqual<T>(this Span<T> span, ReadOnlySpan<T> second)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SequenceEqual(new SpanEnumerator<T, T, IdentityOperator<T>>(second, new()), EqualityComparer<T>.Default);
        }

        public static bool SequenceEqual<T, TComparer>(this Span<T> span, ReadOnlySpan<T> second, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SequenceEqual(new SpanEnumerator<T, T, IdentityOperator<T>>(second, new()), comparer);
        }

        public static bool SequenceEqual<T, TSpan2, TOperator2>(this Span<T> span, SpanEnumerator<TSpan2, T, TOperator2> second)
            where TOperator2 : ISpanOperator<TSpan2, T>
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SequenceEqual(second, EqualityComparer<T>.Default);
        }

        public static bool SequenceEqual<T, TSpan2, TOperator2, TComparer>(this Span<T> span, SpanEnumerator<TSpan2, T, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSpan2, T>
            where TComparer : IEqualityComparer<T>
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SequenceEqual(second, comparer);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public bool SequenceEqual<TSpan2, TOperator2>(SpanEnumerator<TSpan2, TOut, TOperator2> second)
            where TOperator2 : ISpanOperator<TSpan2, TOut>
        {
            return SequenceEqual(second, EqualityComparer<TOut>.Default);
        }

        public bool SequenceEqual<TSpan2, TOperator2, TComparer>(SpanEnumerator<TSpan2, TOut, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSpan2, TOut>
            where TComparer : IEqualityComparer<TOut>
        {
            while (true)
            {
                var current1 = Operator.TryMoveNext(ref Source, out bool ok1);
                var current2 = second.Operator.TryMoveNext(ref second.Source, out bool ok2);

                if (ok1 != ok2)
                {
                    return false;
                }

                if (!ok1) /*implies !ok2 == true*/
                {
                    return true;
                }

                if (!comparer.Equals(current1, current2))
                {
                    return false;
                }
            }
        }
    }
}
