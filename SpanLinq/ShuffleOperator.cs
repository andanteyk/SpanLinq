using System.Buffers;
using System.Security.Cryptography;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, ShuffleOperator<T, T, IdentityOperator<T>>> Shuffle<T>(this ReadOnlySpan<T> span)
        {
            return new(span, new(new(), RandomHelper.GetSharedRandom()));
        }

        public static SpanEnumerator<T, T, ShuffleOperator<T, T, IdentityOperator<T>>> Shuffle<T>(this ReadOnlySpan<T> span, Random random)
        {
            return new(span, new(new(), random));
        }


        public static SpanEnumerator<T, T, ShuffleOperator<T, T, IdentityOperator<T>>> Shuffle<T>(this Span<T> span)
        {
            return new(span, new(new(), RandomHelper.GetSharedRandom()));
        }

        public static SpanEnumerator<T, T, ShuffleOperator<T, T, IdentityOperator<T>>> Shuffle<T>(this Span<T> span, Random random)
        {
            return new(span, new(new(), random));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, ShuffleOperator<TSource, TOut, TOperator>> Shuffle()
        {
            return new(Source, new(Operator, RandomHelper.GetSharedRandom()));
        }

        public SpanEnumerator<TSource, TOut, ShuffleOperator<TSource, TOut, TOperator>> Shuffle(Random random)
        {
            return new(Source, new(Operator, random));
        }
    }

    public struct ShuffleOperator<TSpan, TIn, TOperator> : ISpanOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;
        internal Random Random;
        internal TIn[] Source;
        internal int Index;

        internal ShuffleOperator(TOperator op, Random random)
        {
            Operator = op;
            Random = random;

            Source = null!;
            Index = int.MinValue;
        }

        public void Dispose()
        {
            if (Source != null)
            {
                ArrayPool<TIn>.Shared.Return(Source);
                Source = null!;
            }
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            return Operator.TryGetNonEnumeratedCount(source, out length);
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Index == int.MinValue)
            {
                var sourceSpan = SpanEnumerator<TSpan, TIn, TOperator>.ToArrayPool(source, Operator, out Source);

                for (int i = 1; i < sourceSpan.Length; i++)
                {
                    int r = Random.Next(i + 1);

                    (sourceSpan[i], sourceSpan[r]) = (sourceSpan[r], sourceSpan[i]);
                }

                Index = sourceSpan.Length - 1;
            }
            if (Index == -1)
            {
                Dispose();
            }

            success = Index >= 0;
            return success ? Source![Index--] : default!;
        }
    }

    internal static class RandomHelper
    {
#if NET6_0_OR_GREATER
        internal static Random GetSharedRandom()
        {
            return Random.Shared;
        }
#else
        [ThreadStatic]
        private static Random? SharedRandom;
        internal static Random GetSharedRandom()
        {
            return SharedRandom ??= new Random();
        }
#endif
    }
}

