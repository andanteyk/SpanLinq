using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, ExceptByOperator<T, T, IdentityOperator<T>, TKey, EqualityComparer<TKey>>> ExceptBy<T, TKey>(this ReadOnlySpan<T> span, ReadOnlySpan<TKey> second, Func<T, TKey> keySelector)
        {
            return new(span, new(new(), second, keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, ExceptByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> ExceptBy<T, TKey, TComparer>(this ReadOnlySpan<T> span, ReadOnlySpan<TKey> second, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), second, keySelector, comparer));
        }

        public static SpanEnumerator<T, T, ExceptByOperator<T, T, IdentityOperator<T>, TKey, EqualityComparer<TKey>>> ExceptBy<T, TSecondSource, TSecondOperator, TKey>(this ReadOnlySpan<T> span, SpanEnumerator<TSecondSource, TKey, TSecondOperator> second, Func<T, TKey> keySelector)
            where TSecondOperator : ISpanOperator<TSecondSource, TKey>
        {
            return new(span, ExceptByOperator<T, T, IdentityOperator<T>, TKey, EqualityComparer<TKey>>.Create(new(), second, keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, ExceptByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> ExceptBy<T, TSecondSource, TSecondOperator, TKey, TComparer>(this ReadOnlySpan<T> span, SpanEnumerator<TSecondSource, TKey, TSecondOperator> second, Func<T, TKey> keySelector, TComparer comparer)
            where TSecondOperator : ISpanOperator<TSecondSource, TKey>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, ExceptByOperator<T, T, IdentityOperator<T>, TKey, TComparer>.Create(new(), second, keySelector, comparer));
        }


        public static SpanEnumerator<T, T, ExceptByOperator<T, T, IdentityOperator<T>, TKey, EqualityComparer<TKey>>> ExceptBy<T, TKey>(this Span<T> span, ReadOnlySpan<TKey> second, Func<T, TKey> keySelector)
        {
            return new(span, new(new(), second, keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, ExceptByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> ExceptBy<T, TKey, TComparer>(this Span<T> span, ReadOnlySpan<TKey> second, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), second, keySelector, comparer));
        }

        public static SpanEnumerator<T, T, ExceptByOperator<T, T, IdentityOperator<T>, TKey, EqualityComparer<TKey>>> ExceptBy<T, TSecondSource, TSecondOperator, TKey>(this Span<T> span, SpanEnumerator<TSecondSource, TKey, TSecondOperator> second, Func<T, TKey> keySelector)
            where TSecondOperator : ISpanOperator<TSecondSource, TKey>
        {
            return new(span, ExceptByOperator<T, T, IdentityOperator<T>, TKey, EqualityComparer<TKey>>.Create(new(), second, keySelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, ExceptByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> ExceptBy<T, TSecondSource, TSecondOperator, TKey, TComparer>(this Span<T> span, SpanEnumerator<TSecondSource, TKey, TSecondOperator> second, Func<T, TKey> keySelector, TComparer comparer)
            where TSecondOperator : ISpanOperator<TSecondSource, TKey>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, ExceptByOperator<T, T, IdentityOperator<T>, TKey, TComparer>.Create(new(), second, keySelector, comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, ExceptByOperator<TSource, TOut, TOperator, TKey, EqualityComparer<TKey>>> ExceptBy<TKey, TComparer>(ReadOnlySpan<TKey> second, Func<TOut, TKey> keySelector)
        {
            return new(Source, new(Operator, second, keySelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, TOut, ExceptByOperator<TSource, TOut, TOperator, TKey, TComparer>> ExceptBy<TKey, TComparer>(ReadOnlySpan<TKey> second, Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, second, keySelector, comparer));
        }

        public SpanEnumerator<TSource, TOut, ExceptByOperator<TSource, TOut, TOperator, TKey, EqualityComparer<TKey>>> ExceptBy<TSecondSource, TSecondOperator, TKey>(SpanEnumerator<TSecondSource, TKey, TSecondOperator> second, Func<TOut, TKey> keySelector)
            where TSecondOperator : ISpanOperator<TSecondSource, TKey>
        {
            return new(Source, ExceptByOperator<TSource, TOut, TOperator, TKey, EqualityComparer<TKey>>.Create(Operator, second, keySelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, TOut, ExceptByOperator<TSource, TOut, TOperator, TKey, TComparer>> ExceptBy<TSecondSource, TSecondOperator, TKey, TComparer>(SpanEnumerator<TSecondSource, TKey, TSecondOperator> second, Func<TOut, TKey> keySelector, TComparer comparer)
            where TSecondOperator : ISpanOperator<TSecondSource, TKey>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, ExceptByOperator<TSource, TOut, TOperator, TKey, TComparer>.Create(Operator, second, keySelector, comparer));
        }
    }

    /// <remarks>
    /// `second` will be evaluated instantly.
    /// </remarks>
    public struct ExceptByOperator<TSpan, TIn, TOperator, TKey, TComparer> : ISpanOperator<TSpan, TIn>
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator Operator;
#nullable disable   // TODO: avoid CS8714
        internal ArrayPoolDictionary<TKey, byte> Dictionary;
#nullable restore
        internal bool ExistsNull;
        internal Func<TIn, TKey> KeySelector;

        internal ExceptByOperator(TOperator op, ReadOnlySpan<TKey> second, Func<TIn, TKey> keySelector, TComparer comparer)
        {
            Operator = op;
            ExistsNull = false;
            Dictionary = new(second.Length, comparer);
            foreach (var value in second)
            {
                if (value == null)
                {
                    ExistsNull = true;
                }
                else
                {
                    Dictionary[value] = 0;
                }
            }
            KeySelector = keySelector;
        }

        internal static ExceptByOperator<TSpan, TIn, TOperator, TKey, TComparer> Create<TSecondSpan, TSecondOperator>(TOperator op, SpanEnumerator<TSecondSpan, TKey, TSecondOperator> second, Func<TIn, TKey> keySelector, TComparer comparer)
            where TSecondOperator : ISpanOperator<TSecondSpan, TKey>
        {
            var secondSpan = second.ToArrayPool(out var secondArray);
            var result = new ExceptByOperator<TSpan, TIn, TOperator, TKey, TComparer>(op, secondSpan, keySelector, comparer);
            ArrayPool<TKey>.Shared.Return(secondArray);
            return result;
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
                    success = false;
                    return default!;
                }

                var key = KeySelector(current);
                if (key == null)
                {
                    if (ExistsNull)
                    {
                        continue;
                    }
                    else
                    {
                        ExistsNull = true;
                        success = true;
                        return default!;
                    }
                }
                if (Dictionary.TryAdd(key, 0))
                {
                    success = true;
                    return current;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
