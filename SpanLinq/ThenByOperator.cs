using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TSource, TOut, ThenByOperator<TSource, TOut, TOrderOperator, TKey, Comparer<TKey>>> ThenBy<TSource, TOut, TOrderOperator, TKey>(this SpanEnumerator<TSource, TOut, TOrderOperator> source, Func<TOut, TKey> keySelector)
            where TOrderOperator : ISpanOrderOperator<TSource, TOut>
        {
            return new(source.Source, new(source.Operator, keySelector, false, Comparer<TKey>.Default));
        }

        public static SpanEnumerator<TSource, TOut, ThenByOperator<TSource, TOut, TOrderOperator, TKey, TComparer>> ThenBy<TSource, TOut, TOrderOperator, TKey, TComparer>(this SpanEnumerator<TSource, TOut, TOrderOperator> source, Func<TOut, TKey> keySelector, TComparer comparer)
            where TOrderOperator : ISpanOrderOperator<TSource, TOut>
            where TComparer : IComparer<TKey>
        {
            return new(source.Source, new(source.Operator, keySelector, false, comparer));
        }

        public static SpanEnumerator<TSource, TOut, ThenByOperator<TSource, TOut, TOrderOperator, TKey, Comparer<TKey>>> ThenByDescending<TSource, TOut, TOrderOperator, TKey>(this SpanEnumerator<TSource, TOut, TOrderOperator> source, Func<TOut, TKey> keySelector)
            where TOrderOperator : ISpanOrderOperator<TSource, TOut>
        {
            return new(source.Source, new(source.Operator, keySelector, true, Comparer<TKey>.Default));
        }

        public static SpanEnumerator<TSource, TOut, ThenByOperator<TSource, TOut, TOrderOperator, TKey, TComparer>> ThenByDescending<TSource, TOut, TOrderOperator, TKey, TComparer>(this SpanEnumerator<TSource, TOut, TOrderOperator> source, Func<TOut, TKey> keySelector, TComparer comparer)
            where TOrderOperator : ISpanOrderOperator<TSource, TOut>
            where TComparer : IComparer<TKey>
        {
            return new(source.Source, new(source.Operator, keySelector, true, comparer));
        }
    }


    public struct ThenByOperator<TSpan, TIn, TOperator, TKey, TComparer> : ISpanOrderOperator<TSpan, TIn>, IDisposable
        where TOperator : ISpanOrderOperator<TSpan, TIn>
        where TComparer : IComparer<TKey>
    {
        internal TOperator Operator;
        internal readonly Func<TIn, TKey> KeySelector;
        internal readonly TComparer Comparer;
        internal readonly bool IsDescending;

        internal TIn[]? Source;
        internal int[]? Indexes;
        internal int Index, Length;


        internal ThenByOperator(TOperator op, Func<TIn, TKey> keySelector, bool isDescending, TComparer comparer)
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

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            return Operator.TryGetNonEnumeratedCount(source, out length);
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Index == -1)
            {
                Source = Operator.DelegateProcess(source, out Length);
                Indexes = ArrayPool<int>.Shared.Rent(Length);

                ISpanOrderOperator<TSpan, TIn>.Sort(ref this, Source.AsSpan(..Length), Indexes.AsSpan(..Length));

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
            int cmp = Operator.Compare(source, indexA, indexB);
            if (cmp != 0)
                return cmp;

            return IsDescending ?
                Comparer.Compare(KeySelector(source[indexB]), KeySelector(source[indexA])) :
                Comparer.Compare(KeySelector(source[indexA]), KeySelector(source[indexB]));
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

        public TIn[] DelegateProcess(ReadOnlySpan<TSpan> source, out int length)
        {
            var result = Operator.DelegateProcess(source, out length);
            Index = int.MinValue;
            return result;
        }
    }
}
