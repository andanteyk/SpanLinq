namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, PrependOperator<T, T, IdentityOperator<T>>> Prepend<T>(this ReadOnlySpan<T> span, T element)
        {
            return new(span, new(new(), element));
        }

        public static SpanEnumerator<T, T, PrependOperator<T, T, IdentityOperator<T>>> Prepend<T>(this Span<T> span, T element)
        {
            return new(span, new(new(), element));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, PrependOperator<TSource, TOut, TOperator>> Prepend(TOut element)
        {
            return new(Source, new(Operator, element));
        }
    }


    public struct PrependOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal readonly TIn Element;
        internal bool Done;

        internal PrependOperator(TOperator op, TIn element)
        {
            Operator = op;
            Element = element;
            Done = false;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            if (Operator.TryGetNonEnumeratedCount(source, out length))
            {
                length++;
                return true;
            }
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (!Done)
            {
                Done = true;
                success = true;
                return Element;
            }

            return Operator.TryMoveNext(ref source, out success);
        }
    }
}
