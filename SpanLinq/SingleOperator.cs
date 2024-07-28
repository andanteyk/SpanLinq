using System.Runtime.CompilerServices;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T Single<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Single();
        }

        public static T Single<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Single(predicate);
        }

        public static T Single<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Single();
        }

        public static T Single<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Single(predicate);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public TOut Single()
        {
            return Single(x => true);
        }

        public TOut Single(Predicate<TOut> predicate)
        {
            bool found = false;
            Unsafe.SkipInit(out TOut single);

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }

                if (predicate(current))
                {
                    if (found)
                    {
                        throw new InvalidOperationException("Sequence contains more than one element.");
                    }
                    found = true;
                    single = current;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException("Sequence contains no elements.");
            }

            return single;
        }
    }
}
