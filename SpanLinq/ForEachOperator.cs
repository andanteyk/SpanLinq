namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static void ForEach<T>(this ReadOnlySpan<T> span, Action<T> action)
        {
            foreach (var element in span)
            {
                action(element);
            }
        }

        public static void ForEach<T>(this ReadOnlySpan<T> span, Action<T, int> action)
        {
            int index = 0;
            foreach (var element in span)
            {
                action(element, index++);
            }
        }

        public static void ForEach<T>(this Span<T> span, Action<T> action)
        {
            foreach (var element in span)
            {
                action(element);
            }
        }

        public static void ForEach<T>(this Span<T> span, Action<T, int> action)
        {
            int index = 0;
            foreach (var element in span)
            {
                action(element, index++);
            }
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public void ForEach(Action<TOut> action)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }

                action(current);
            }
        }

        public void ForEach(Action<TOut, int> action)
        {
            int index = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }

                action(current, index++);
            }
        }
    }
}
