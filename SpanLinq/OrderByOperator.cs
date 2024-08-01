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


        internal static void Sort<T>(ref T @this, Span<TIn> source, Span<int> indexes)
            where T : ISpanOrderOperator<TSpan, TIn>
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = i;
            }

            IntroSort(ref @this, source, indexes);
        }


        private static int CompareWithIndex<T>(ref T @this, ReadOnlySpan<TIn> source, int indexA, int indexB)
            where T : ISpanOrderOperator<TSpan, TIn>
        {
            int cmp = @this.Compare(source, indexA, indexB);
            if (cmp != 0)
                return cmp;

            return indexA - indexB;
        }

        private static int DoPartitioning<T>(ref T @this, Span<TIn> source, Span<int> index)
            where T : ISpanOrderOperator<TSpan, TIn>
        {
            int pivot;
            pivot = index.Length / 2;

            int lo = 0;
            int hi = index.Length - 1;
            while (true)
            {
                for (; lo < index.Length && CompareWithIndex(ref @this, source, index[lo], index[pivot]) < 0; lo++) ;
                for (; hi >= 0 && CompareWithIndex(ref @this, source, index[pivot], index[hi]) < 0; hi--) ;

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

        private static void QuickSort<T>(ref T @this, Span<TIn> source, Span<int> index)
            where T : ISpanOrderOperator<TSpan, TIn>
        {
            if (index.Length <= 16)
            {
                InsertionSort(ref @this, source, index);
                return;
            }

            int p = DoPartitioning(ref @this, source, index);
            QuickSort(ref @this, source, index[..p]);
            QuickSort(ref @this, source, index[p..]);
        }

        private static void InsertionSort<T>(ref T @this, Span<TIn> source, Span<int> index)
            where T : ISpanOrderOperator<TSpan, TIn>
        {
            for (int i = 1; i < index.Length; i++)
            {
                if (@this.Compare(source, index[i - 1], index[i]) > 0)
                {
                    int k = i;
                    var temp = index[i];
                    do
                    {
                        index[k] = index[k - 1];
                        k--;
                    } while (k > 0 && @this.Compare(source, index[k - 1], temp) > 0);
                    index[k] = temp;
                }
            }
        }

        private static void HeapSort<T>(ref T @this, Span<TIn> source, Span<int> index)
            where T : ISpanOrderOperator<TSpan, TIn>
        {
            static int LeftChild(int i) => 2 * i + 1;
            static int RightChild(int i) => 2 * i + 2;
            static int Parent(int i) => (i - 1) / 2;

            static void Heapify(ref T @this, Span<TIn> source, Span<int> index)
            {
                int start = Parent(index.Length - 1) + 1;

                while (start > 0)
                {
                    start--;
                    SiftDown(ref @this, source, index, start, index.Length);
                }
            }

            static void SiftDown(ref T @this, Span<TIn> source, Span<int> index, int start, int end)
            {
                int j = LeafSearch(ref @this, source, index, start, end);
                while (CompareWithIndex(ref @this, source, index[start], index[j]) > 0)
                {
                    j = Parent(j);
                }
                while (j > start)
                {
                    (index[start], index[j]) = (index[j], index[start]);
                    j = Parent(j);
                }
            }

            static int LeafSearch(ref T @this, Span<TIn> source, Span<int> index, int i, int end)
            {
                int j = i;
                while (RightChild(j) < end)
                {
                    if (CompareWithIndex(ref @this, source, index[RightChild(j)], index[LeftChild(j)]) > 0)
                    {
                        j = RightChild(j);
                    }
                    else
                    {
                        j = LeftChild(j);
                    }
                }

                if (LeftChild(j) < end)
                {
                    j = LeftChild(j);
                }

                return j;
            }


            Heapify(ref @this, source, index);
            int end = index.Length;
            while (end > 1)
            {
                end--;
                (index[0], index[end]) = (index[end], index[0]);
                SiftDown(ref @this, source, index, 0, end);
            }
        }

        private static int Log2(int x)
        {
#if NETCOREAPP3_0_OR_GREATER
            return System.Numerics.BitOperations.Log2((uint)x);
#else
            x |= 1;
            int n = 1;
            if (((uint)x >> 16) == 0) { n += 16; x <<= 16; }
            if (((uint)x >> 24) == 0) { n += 8; x <<= 8; }
            if (((uint)x >> 28) == 0) { n += 4; x <<= 4; }
            if (((uint)x >> 30) == 0) { n += 2; x <<= 2; }
            n = n - (int)((uint)x >> 31);
            return 31 - n;
#endif
        }

        private static void IntroSort<T>(ref T @this, Span<TIn> source, Span<int> index)
            where T : ISpanOrderOperator<TSpan, TIn>
        {
            int maxDepth = 2 * Log2(index.Length);
            IntroSortImpl(ref @this, source, index, maxDepth);
        }

        private static void IntroSortImpl<T>(ref T @this, Span<TIn> source, Span<int> index, int maxDepth)
            where T : ISpanOrderOperator<TSpan, TIn>
        {
            if (index.Length <= 16)
            {
                InsertionSort(ref @this, source, index);
                return;
            }

            if (maxDepth == 0)
            {
                HeapSort(ref @this, source, index);
                return;
            }

            int p = DoPartitioning(ref @this, source, index);
            IntroSortImpl(ref @this, source, index[..p], maxDepth - 1);
            IntroSortImpl(ref @this, source, index[p..], maxDepth - 1);
        }
    }


    internal static class OrderHelper<T>
    {
        internal static Func<T, T> IdentityFunction = x => x;
    }

    public struct OrderByOperator<TSpan, TIn, TOperator, TKey, TComparer> : ISpanOrderOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IComparer<TKey>
    {
        internal TOperator Operator;
        internal Func<TIn, TKey> KeySelector;
        internal TComparer Comparer;
        internal bool IsDescending;

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
                var indexSpan = Indexes.AsSpan(..Length);

                ISpanOrderOperator<TSpan, TIn>.Sort(ref this, sourceSpan, indexSpan);

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
            return IsDescending ?
                Comparer.Compare(KeySelector(source[indexB]), KeySelector(source[indexA])) :
                Comparer.Compare(KeySelector(source[indexA]), KeySelector(source[indexB]));
        }

        public TIn[] DelegateProcess(ReadOnlySpan<TSpan> source, out int length)
        {
            var sourceSpan = SpanEnumerator<TSpan, TIn, TOperator>.ToArrayPool(source, Operator, out var result);
            length = sourceSpan.Length;
            Index = int.MinValue;
            return result;
        }


    }
}
