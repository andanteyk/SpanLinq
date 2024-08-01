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

            QuickSort(ref @this, source, indexes);
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
            if (index.Length <= 2)
            {
                if (CompareWithIndex(ref @this, source, index[0], index[^1]) > 0)
                {
                    (index[0], index[^1]) = (index[^1], index[0]);
                }
                return;
            }

            int p = DoPartitioning(ref @this, source, index);
            QuickSort(ref @this, source, index[..p]);
            QuickSort(ref @this, source, index[p..]);
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
