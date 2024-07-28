namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static bool Contains<T>(this ReadOnlySpan<T> span, T element)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Contains(element);
        }

        public static bool Contains<T, TComparer>(this ReadOnlySpan<T> span, T element, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Contains(element, comparer);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public bool Contains(TOut element)
        {
            return Contains(element, EqualityComparer<TOut>.Default);
        }

        public bool Contains<TComparer>(TOut element, TComparer comparer)
            where TComparer : IEqualityComparer<TOut>
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }

                if (comparer.Equals(current, element))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
