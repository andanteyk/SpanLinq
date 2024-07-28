using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, ConcatOperator<T, T, IdentityOperator<T>, TSecond, TSecondOperator>> Concat<T, TSecond, TSecondOperator>(this ReadOnlySpan<T> span, SpanEnumerator<TSecond, T, TSecondOperator> second)
            where TSecondOperator : ISpanOperator<TSecond, T>
        {
            return new(span, new(new(), second));
        }

        public static SpanEnumerator<T, T, ConcatOperator<T, T, IdentityOperator<T>>> Concat<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> second)
        {
            return new(span, new(new(), second));
        }

        public static SpanEnumerator<T, T, ConcatOperator<T, T, IdentityOperator<T>, TSecond, TSecondOperator>> Concat<T, TSecond, TSecondOperator>(this Span<T> span, SpanEnumerator<TSecond, T, TSecondOperator> second)
            where TSecondOperator : ISpanOperator<TSecond, T>
        {
            return new(span, new(new(), second));
        }

        public static SpanEnumerator<T, T, ConcatOperator<T, T, IdentityOperator<T>>> Concat<T>(this Span<T> span, ReadOnlySpan<T> second)
        {
            return new(span, new(new(), second));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, ConcatOperator<TSource, TOut, TOperator, TSecond, TSecondOperator>> Concat<TSecond, TSecondOperator>(SpanEnumerator<TSecond, TOut, TSecondOperator> second)
             where TSecondOperator : ISpanOperator<TSecond, TOut>
        {
            return new(Source, new(Operator, second));
        }

        public SpanEnumerator<TSource, TOut, ConcatOperator<TSource, TOut, TOperator>> Concat<TSecond, TSecondOperator>(ReadOnlySpan<TOut> second)
             where TSecondOperator : ISpanOperator<TSecond, TOut>
        {
            return new(Source, new(Operator, second));
        }
    }

    /// <remarks>
    /// TODO: This implementation is NOT using deferred execution, due to cannot have ref struct.
    /// Changing ConcatOperator to a ref struct would prevent it from implementing the interface.
    /// </remarks>
    public struct ConcatOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal TIn[] SecondArray;
        internal int SecondIndex;
        internal int SecondLength;

        internal ConcatOperator(TOperator op, ReadOnlySpan<TIn> second)
        {
            Operator = op;
            SecondArray = ArrayPool<TIn>.Shared.Rent(second.Length);
            second.CopyTo(SecondArray.AsSpan());
            SecondIndex = -1;
            SecondLength = second.Length;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (SecondIndex >= 0)
            {
                if (SecondIndex < SecondLength)
                {
                    success = true;
                    return SecondArray[SecondIndex++];
                }
                else if (SecondIndex == SecondLength)
                {
                    Dispose();
                }

                success = false;
                return default!;
            }

            var current = Operator.TryMoveNext(ref source, out bool ok);
            if (!ok)
            {
                SecondIndex = 0;
                if (SecondIndex < SecondLength)
                {
                    success = true;
                    return SecondArray[SecondIndex++];
                }

                success = false;
                return default!;
            }

            success = true;
            return current;
        }

        public void Dispose()
        {
            if (SecondArray != null)
            {
                ArrayPool<TIn>.Shared.Return(SecondArray);
                SecondArray = null!;
            }
        }
    }

    /// <remarks>
    /// TODO: This implementation is NOT using deferred execution, due to cannot have ref struct.
    /// Changing ConcatOperator to a ref struct would prevent it from implementing the interface.
    /// </remarks>
    public struct ConcatOperator<TSpan, TIn, TOperator, TSecondSpan, TSecondOperator> : ISpanOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TSecondOperator : ISpanOperator<TSecondSpan, TIn>
    {
        internal TOperator Operator;
        internal TIn[] SecondArray;
        internal int SecondIndex;
        internal int SecondLength;

        internal ConcatOperator(TOperator op, SpanEnumerator<TSecondSpan, TIn, TSecondOperator> second)
        {
            Operator = op;
            var secondSpan = second.ToArrayPool(out SecondArray);
            SecondIndex = -1;
            SecondLength = secondSpan.Length;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (SecondIndex >= 0)
            {
                if (SecondIndex < SecondLength)
                {
                    success = true;
                    return SecondArray[SecondIndex++];
                }
                else if (SecondIndex == SecondLength)
                {
                    Dispose();
                }

                success = false;
                return default!;
            }

            var current = Operator.TryMoveNext(ref source, out bool ok);
            if (!ok)
            {
                SecondIndex = 0;
                if (SecondIndex < SecondLength)
                {
                    success = true;
                    return SecondArray[SecondIndex++];
                }

                success = false;
                return default!;
            }

            success = true;
            return current;
        }

        public void Dispose()
        {
            if (SecondArray != null)
            {
                ArrayPool<TIn>.Shared.Return(SecondArray);
                SecondArray = null!;
            }
        }
    }
}
