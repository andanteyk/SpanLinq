using System.Runtime.CompilerServices;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static T SingleOrDefault<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SingleOrDefault();
        }

        public static T SingleOrDefault<T>(this ReadOnlySpan<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SingleOrDefault(predicate);
        }

        public static T SingleOrDefault<T>(this ReadOnlySpan<T> span, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SingleOrDefault(defaultValue);
        }

        public static T SingleOrDefault<T>(this ReadOnlySpan<T> span, Predicate<T> predicate, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SingleOrDefault(predicate, defaultValue);
        }


        public static T SingleOrDefault<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SingleOrDefault();
        }

        public static T SingleOrDefault<T>(this Span<T> span, Predicate<T> predicate)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SingleOrDefault(predicate);
        }

        public static T SingleOrDefault<T>(this Span<T> span, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SingleOrDefault(defaultValue);
        }

        public static T SingleOrDefault<T>(this Span<T> span, Predicate<T> predicate, T defaultValue)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).SingleOrDefault(predicate, defaultValue);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public TOut SingleOrDefault()
        {
            return SingleOrDefault(_ => true, default!);
        }

        public TOut SingleOrDefault(Predicate<TOut> predicate)
        {
            return SingleOrDefault(predicate, default!);
        }

        public TOut SingleOrDefault(TOut defaultValue)
        {
            return SingleOrDefault(_ => true, defaultValue);
        }

        public TOut SingleOrDefault(Predicate<TOut> predicate, TOut defaultValue)
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
                        // second
                        return defaultValue;
                    }
                    found = true;
                    single = current;
                }
            }

            if (!found)
            {
                // not found
                return defaultValue;
            }

            return single;
        }
    }
}
