using System.Buffers;
using System.Transactions;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, ExceptOperator<T, T, IdentityOperator<T>, EqualityComparer<T>>> Except<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> second)
        {
            return new(span, new(new(), second, EqualityComparer<T>.Default));
        }

        public static SpanEnumerator<T, T, ExceptOperator<T, T, IdentityOperator<T>, TComparer>> Except<T, TComparer>(this ReadOnlySpan<T> span, ReadOnlySpan<T> second, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new(span, new(new(), second, comparer));
        }

        public static SpanEnumerator<T, T, ExceptOperator<T, T, IdentityOperator<T>, EqualityComparer<T>>> Except<T, TSecondSource, TSecondOperator>(this ReadOnlySpan<T> span, SpanEnumerator<TSecondSource, T, TSecondOperator> second)
            where TSecondOperator : ISpanOperator<TSecondSource, T>
        {
            return new(span, ExceptOperator<T, T, IdentityOperator<T>, EqualityComparer<T>>.Create(new(), second, EqualityComparer<T>.Default));
        }

        public static SpanEnumerator<T, T, ExceptOperator<T, T, IdentityOperator<T>, TComparer>> Except<T, TSecondSource, TSecondOperator, TComparer>(this ReadOnlySpan<T> span, SpanEnumerator<TSecondSource, T, TSecondOperator> second, TComparer comparer)
            where TSecondOperator : ISpanOperator<TSecondSource, T>
            where TComparer : IEqualityComparer<T>
        {
            return new(span, ExceptOperator<T, T, IdentityOperator<T>, TComparer>.Create(new(), second, comparer));
        }


        public static SpanEnumerator<T, T, ExceptOperator<T, T, IdentityOperator<T>, EqualityComparer<T>>> Except<T>(this Span<T> span, ReadOnlySpan<T> second)
        {
            return new(span, new(new(), second, EqualityComparer<T>.Default));
        }

        public static SpanEnumerator<T, T, ExceptOperator<T, T, IdentityOperator<T>, TComparer>> Except<T, TComparer>(this Span<T> span, ReadOnlySpan<T> second, TComparer comparer)
            where TComparer : IEqualityComparer<T>
        {
            return new(span, new(new(), second, comparer));
        }

        public static SpanEnumerator<T, T, ExceptOperator<T, T, IdentityOperator<T>, EqualityComparer<T>>> Except<T, TSecondSource, TSecondOperator>(this Span<T> span, SpanEnumerator<TSecondSource, T, TSecondOperator> second)
            where TSecondOperator : ISpanOperator<TSecondSource, T>
        {
            return new(span, ExceptOperator<T, T, IdentityOperator<T>, EqualityComparer<T>>.Create(new(), second, EqualityComparer<T>.Default));
        }

        public static SpanEnumerator<T, T, ExceptOperator<T, T, IdentityOperator<T>, TComparer>> Except<T, TSecondSource, TSecondOperator, TComparer>(this Span<T> span, SpanEnumerator<TSecondSource, T, TSecondOperator> second, TComparer comparer)
            where TSecondOperator : ISpanOperator<TSecondSource, T>
            where TComparer : IEqualityComparer<T>
        {
            return new(span, ExceptOperator<T, T, IdentityOperator<T>, TComparer>.Create(new(), second, comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, ExceptOperator<TSource, TOut, TOperator, EqualityComparer<TOut>>> Except<TComparer>(ReadOnlySpan<TOut> second)
        {
            return new(Source, new(Operator, second, EqualityComparer<TOut>.Default));
        }

        public SpanEnumerator<TSource, TOut, ExceptOperator<TSource, TOut, TOperator, TComparer>> Except<TComparer>(ReadOnlySpan<TOut> second, TComparer comparer)
            where TComparer : IEqualityComparer<TOut>
        {
            return new(Source, new(Operator, second, comparer));
        }

        public SpanEnumerator<TSource, TOut, ExceptOperator<TSource, TOut, TOperator, EqualityComparer<TOut>>> Except<TSecondSource, TSecondOperator>(SpanEnumerator<TSecondSource, TOut, TSecondOperator> second)
            where TSecondOperator : ISpanOperator<TSecondSource, TOut>
        {
            return new(Source, ExceptOperator<TSource, TOut, TOperator, EqualityComparer<TOut>>.Create(Operator, second, EqualityComparer<TOut>.Default));
        }

        public SpanEnumerator<TSource, TOut, ExceptOperator<TSource, TOut, TOperator, TComparer>> Except<TSecondSource, TSecondOperator, TComparer>(SpanEnumerator<TSecondSource, TOut, TSecondOperator> second, TComparer comparer)
            where TSecondOperator : ISpanOperator<TSecondSource, TOut>
            where TComparer : IEqualityComparer<TOut>
        {
            return new(Source, ExceptOperator<TSource, TOut, TOperator, TComparer>.Create(Operator, second, comparer));
        }
    }

    /// <remarks>
    /// `second` will be evaluated instantly.
    /// </remarks>
    public struct ExceptOperator<TSpan, TIn, TOperator, TComparer> : ISpanOperator<TSpan, TIn>
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IEqualityComparer<TIn>
    {
        internal TOperator Operator;
#nullable disable   // TODO: avoid CS8714
        internal ArrayPoolDictionary<TIn, byte> Dictionary;
#nullable restore
        internal bool ExistsNull;

        internal ExceptOperator(TOperator op, ReadOnlySpan<TIn> second, TComparer comparer)
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
        }

        internal static ExceptOperator<TSpan, TIn, TOperator, TComparer> Create<TSecondSpan, TSecondOperator>(TOperator op, SpanEnumerator<TSecondSpan, TIn, TSecondOperator> second, TComparer comparer)
            where TSecondOperator : ISpanOperator<TSecondSpan, TIn>
        {
            var secondSpan = second.ToArrayPool(out var secondArray);
            var result = new ExceptOperator<TSpan, TIn, TOperator, TComparer>(op, secondSpan, comparer);
            ArrayPool<TIn>.Shared.Return(secondArray);
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

                if (current == null)
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
                if (Dictionary.TryAdd(current, 0))
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
