using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, TKey, Comparer<TKey>>> OrderBy<T, TKey>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector)
        {
            return new(span, new(new(), keySelector, false, Comparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> OrderBy<T, TKey, TComparer>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IComparer<TKey>
        {
            return new(span, new(new(), keySelector, false, comparer));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, TKey, Comparer<TKey>>> OrderBy<T, TKey>(this Span<T> span, Func<T, TKey> keySelector)
        {
            return new(span, new(new(), keySelector, false, Comparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> OrderBy<T, TKey, TComparer>(this Span<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IComparer<TKey>
        {
            return new(span, new(new(), keySelector, false, comparer));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, TKey, Comparer<TKey>>> OrderByDescending<T, TKey>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector)
        {
            return new(span, new(new(), keySelector, true, Comparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> OrderByDescending<T, TKey, TComparer>(this ReadOnlySpan<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IComparer<TKey>
        {
            return new(span, new(new(), keySelector, true, comparer));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, TKey, Comparer<TKey>>> OrderByDescending<T, TKey>(this Span<T> span, Func<T, TKey> keySelector)
        {
            return new(span, new(new(), keySelector, true, Comparer<TKey>.Default));
        }

        public static SpanEnumerator<T, T, OrderByOperator<T, T, IdentityOperator<T>, TKey, TComparer>> OrderByDescending<T, TKey, TComparer>(this Span<T> span, Func<T, TKey> keySelector, TComparer comparer)
            where TComparer : IComparer<TKey>
        {
            return new(span, new(new(), keySelector, true, comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOut, OrderByOperator<TSource, TOut, TOperator, TKey, Comparer<TKey>>> OrderBy<TKey>(Func<TOut, TKey> keySelector)
        {
            return new(Source, new(Operator, keySelector, false, Comparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, TOut, OrderByOperator<TSource, TOut, TOperator, TKey, TComparer>> OrderBy<TKey, TComparer>(Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, false, comparer));
        }

        public SpanEnumerator<TSource, TOut, OrderByOperator<TSource, TOut, TOperator, TKey, Comparer<TKey>>> OrderByDescending<TKey>(Func<TOut, TKey> keySelector)
        {
            return new(Source, new(Operator, keySelector, true, Comparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, TOut, OrderByOperator<TSource, TOut, TOperator, TKey, TComparer>> OrderByDescending<TKey, TComparer>(Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, true, comparer));
        }
    }


    public interface ISpanOrderOperator<TSpan, TIn> : ISpanOperator<TSpan, TIn>
    {
        public int Compare(ReadOnlySpan<TIn> source, int indexA, int indexB);
        public TIn[] DelegateProcess(ReadOnlySpan<TSpan> source, out int length);
    }


    public struct OrderByOperator<TSpan, TIn, TOperator, TKey, TComparer> : ISpanOrderOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IComparer<TKey>
    {
        internal TOperator Operator;
        internal readonly Func<TIn, TKey> KeySelector;
        internal readonly TComparer Comparer;
        internal readonly bool IsDescending;
        internal TIn[]? Source;
        internal int[]? Indexes;
        internal int Index, Length;

        internal OrderByOperator(TOperator op, Func<TIn, TKey> keySelector, bool isDescending, TComparer comparer)
        {
            Operator = op;
            KeySelector = keySelector;
            IsDescending = isDescending;
            Comparer = comparer;

            Source = null;
            Indexes = null;
            Index = -1;
            Length = -1;
        }

        public void Dispose()
        {
            if (Source != null)
            {
                ArrayPool<TIn>.Shared.Return(Source);
                Source = null;
            }
            if (Indexes != null)
            {
                ArrayPool<int>.Shared.Return(Indexes);
                Indexes = null;
            }
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            return Operator.TryGetNonEnumeratedCount(source, out length);
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Index == -1)
            {
                var sourceSpan = SpanEnumerator<TSpan, TIn, TOperator>.ToArrayPool(source, Operator, out Source);
                Length = sourceSpan.Length;
                Indexes = ArrayPool<int>.Shared.Rent(sourceSpan.Length);

                OrderHelper<TIn>.Sort(sourceSpan, Indexes.AsSpan(..sourceSpan.Length), Compare);

                Index = 0;
            }

            if (Index < Length)
            {
                var result = Source![Indexes![Index]];
                Index++;
                success = true;
                return result;
            }
            else if (Index == Length)
            {
                Dispose();
                Index = int.MinValue;
            }

            success = false;
            return default!;
        }

        public int Compare(ReadOnlySpan<TIn> source, int indexA, int indexB)
        {
            TComparer comparer = Comparer;

            return IsDescending ?
                comparer.Compare(KeySelector(source[indexB]), KeySelector(source[indexA])) :
                comparer.Compare(KeySelector(source[indexA]), KeySelector(source[indexB]));
        }

        public TIn[] DelegateProcess(ReadOnlySpan<TSpan> source, out int length)
        {
            var sourceSpan = SpanEnumerator<TSpan, TIn, TOperator>.ToArrayPool(source, Operator, out var result);
            length = sourceSpan.Length;
            Index = int.MinValue;
            return result;
        }
    }

    internal static class OrderHelper<TIn>
    {
        internal delegate int CompareDelegate(ReadOnlySpan<TIn> source, int indexA, int indexB);

        internal static void Sort(Span<TIn> source, Span<int> indexes, CompareDelegate compareMethod)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = i;
            }

            QuickSort(source, indexes, compareMethod);
        }

        static int Compare(ReadOnlySpan<TIn> source, int indexA, int indexB, CompareDelegate compareMethod)
        {
            int cmp = compareMethod(source, indexA, indexB);
            if (cmp != 0)
                return cmp;

            return indexA - indexB;
        }

        static int DoPartitioning(Span<TIn> source, Span<int> index, CompareDelegate compareMethod)
        {
            int pivot;
            pivot = index.Length / 2;

            int lo = 0;
            int hi = index.Length - 1;
            while (true)
            {
                for (; lo < index.Length && Compare(source, index[lo], index[pivot], compareMethod) < 0; lo++) ;
                for (; hi >= 0 && Compare(source, index[pivot], index[hi], compareMethod) < 0; hi--) ;

                if (lo < hi)
                {
                    (index[lo], index[hi]) = (index[hi], index[lo]);

                    if (pivot == lo)
                        pivot = hi;
                    else if (pivot == hi)
                        pivot = lo;

                    lo++;
                    hi--;
                }
                else
                {
                    return hi + 1;
                }
            }
        }

        static void QuickSort(Span<TIn> source, Span<int> index, CompareDelegate comparer)
        {
            if (index.Length <= 2)
            {
                if (Compare(source, index[0], index[^1], comparer) > 0)
                {
                    (index[0], index[^1]) = (index[^1], index[0]);
                }
                return;
            }

            int p = DoPartitioning(source, index, comparer);
            QuickSort(source, index[..p], comparer);
            QuickSort(source, index[p..], comparer);
        }
    }
}
