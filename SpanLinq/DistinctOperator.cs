namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, DistinctOperator<T, T, IdentityOperator<T>, EqualityComparer<T>>> Distinct<T>(this ReadOnlySpan<T> span)
        {
            return new(span, new(new(), EqualityComparer<T>.Default));
        }

        public static SpanEnumerator<T, T, DistinctOperator<T, T, IdentityOperator<T>, TComparer>> Distinct<T, TComparer>(this ReadOnlySpan<T> span, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new(span, new(new(), comparer));
        }

        public static SpanEnumerator<T, T, DistinctOperator<T, T, IdentityOperator<T>, EqualityComparer<T>>> Distinct<T>(this Span<T> span)
        {
            return new(span, new(new(), EqualityComparer<T>.Default));
        }

        public static SpanEnumerator<T, T, DistinctOperator<T, T, IdentityOperator<T>, TComparer>> Distinct<T, TComparer>(this Span<T> span, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new(span, new(new(), comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, DistinctOperator<TSource, TOut, TOperator, EqualityComparer<TOut>>> Distinct()
        {
            return new(Source, new(Operator, EqualityComparer<TOut>.Default));
        }

        public SpanEnumerator<TSource, TOut, DistinctOperator<TSource, TOut, TOperator, TComparer>> Distinct<TComparer>(TComparer comparer)
            where TComparer : IEqualityComparer<TOut>
        {
            return new(Source, new(Operator, comparer));
        }
    }

    public struct DistinctOperator<TSpan, TIn, TOperator, TComparer> : ISpanOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IEqualityComparer<TIn>
    {
        internal TOperator Operator;
        internal readonly TComparer Comparer;

        internal ArrayPoolDictionary<TIn, Unit>? Dictionary;

        internal DistinctOperator(TOperator op, TComparer comparer)
        {
            Operator = op;
            Comparer = comparer;
            Dictionary = null;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref source, out bool ok);
                if (!ok)
                {
                    Dispose();
                    success = false;
                    return default!;
                }

                if (Dictionary == null)
                {
                    Dictionary = ObjectPool.SharedRent<ArrayPoolDictionary<TIn, Unit>>();
                    Dictionary.ClearAndSetComparer(Comparer);
                }

                if (Dictionary.TryAdd(current, default))
                {
                    success = true;
                    return current;
                }
            }
        }

        public void Dispose()
        {
            if (Dictionary != null)
            {
                ObjectPool.SharedReturn(Dictionary);
                Dictionary = null;
            }
        }
    }
}