namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, AppendOperator<T, T, IdentityOperator<T>>> Append<T>(this ReadOnlySpan<T> span, T element)
        {
            return new(span, new(new(), element));
        }

        public static SpanEnumerator<T, T, AppendOperator<T, T, IdentityOperator<T>>> Append<T>(this Span<T> span, T element)
        {
            return new(span, new(new(), element));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, AppendOperator<TSource, TOut, TOperator>> Append(TOut element)
        {
            return new(Source, new(Operator, element));
        }
    }


    public struct AppendOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal readonly TIn Element;
        internal bool Done;

        internal AppendOperator(TOperator op, TIn element)
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
            var current = Operator.TryMoveNext(ref source, out bool ok);
            if (ok)
            {
                success = true;
                return current;
            }
            else if (!Done)
            {
                success = true;
                Done = true;
                return Element;
            }
            else
            {
                success = false;
                return default!;
            }
        }
    }
}
