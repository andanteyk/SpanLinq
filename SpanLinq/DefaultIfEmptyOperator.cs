using System.Transactions;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, DefaultIfEmptyOperator<T, T, IdentityOperator<T>>> DefaultIfEmpty<T>(this ReadOnlySpan<T> span)
        {
            return new(span, new(new(), default!));
        }

        public static SpanEnumerator<T, T, DefaultIfEmptyOperator<T, T, IdentityOperator<T>>> DefaultIfEmpty<T>(this ReadOnlySpan<T> span, T element)
        {
            return new(span, new(new(), element));
        }

        public static SpanEnumerator<T, T, DefaultIfEmptyOperator<T, T, IdentityOperator<T>>> DefaultIfEmpty<T>(this Span<T> span)
        {
            return new(span, new(new(), default!));
        }

        public static SpanEnumerator<T, T, DefaultIfEmptyOperator<T, T, IdentityOperator<T>>> DefaultIfEmpty<T>(this Span<T> span, T element)
        {
            return new(span, new(new(), element));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, DefaultIfEmptyOperator<TSource, TOut, TOperator>> DefaultIfEmpty()
        {
            return new(Source, new(Operator, default!));
        }

        public SpanEnumerator<TSource, TOut, DefaultIfEmptyOperator<TSource, TOut, TOperator>> DefaultIfEmpty(TOut element)
        {
            return new(Source, new(Operator, element));
        }
    }

    public struct DefaultIfEmptyOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal readonly TIn Element;
        internal bool Done;

        internal DefaultIfEmptyOperator(TOperator op, TIn element)
        {
            Operator = op;
            Element = element;
            Done = false;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            if (Operator.TryGetNonEnumeratedCount(source, out length))
            {
                if (length == 0)
                {
                    length = 1;
                }
                return true;
            }
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            var current = Operator.TryMoveNext(ref source, out bool ok);
            if (ok)
            {
                Done = true;
                success = true;
                return current;
            }

            if (!Done)
            {
                Done = true;
                success = true;
                return Element;
            }

            success = false;
            return default!;
        }
    }
}
