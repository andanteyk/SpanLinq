using System.Buffers;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, TResult, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<T, TInner, TKey, TResult>(this ReadOnlySpan<T> span, ReadOnlySpan<TInner> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, IEnumerable<TInner>, TResult> resultSelector)
        {
            return new(span, new(new(), inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, TResult, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, TComparer>> GroupJoin<T, TInner, TKey, TResult, TComparer>(this ReadOnlySpan<T> span, ReadOnlySpan<TInner> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), inner, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }

        public static SpanEnumerator<T, TResult, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<T, TInnerSource, TInnerOperator, TInner, TKey, TResult>(this ReadOnlySpan<T> span, SpanEnumerator<TInnerSource, TInner, TInnerOperator> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, IEnumerable<TInner>, TResult> resultSelector)
            where TInnerOperator : ISpanOperator<TInnerSource, TInner>
        {
            return new(span, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, EqualityComparer<TKey>>.Create(new(), inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, TResult, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, TComparer>> GroupJoin<T, TInnerSource, TInnerOperator, TInner, TKey, TResult, TComparer>(this ReadOnlySpan<T> span, SpanEnumerator<TInnerSource, TInner, TInnerOperator> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TInnerOperator : ISpanOperator<TInnerSource, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, TComparer>.Create(new(), inner, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }


        public static SpanEnumerator<T, TResult, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<T, TInner, TKey, TResult>(this Span<T> span, ReadOnlySpan<TInner> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, IEnumerable<TInner>, TResult> resultSelector)
        {
            return new(span, new(new(), inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, TResult, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, TComparer>> GroupJoin<T, TInner, TKey, TResult, TComparer>(this Span<T> span, ReadOnlySpan<TInner> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), inner, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }

        public static SpanEnumerator<T, TResult, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<T, TInnerSource, TInnerOperator, TInner, TKey, TResult>(this Span<T> span, SpanEnumerator<TInnerSource, TInner, TInnerOperator> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, IEnumerable<TInner>, TResult> resultSelector)
            where TInnerOperator : ISpanOperator<TInnerSource, TInner>
        {
            return new(span, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, EqualityComparer<TKey>>.Create(new(), inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<T, TResult, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, TComparer>> GroupJoin<T, TInnerSource, TInnerOperator, TInner, TKey, TResult, TComparer>(this Span<T> span, SpanEnumerator<TInnerSource, TInner, TInnerOperator> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TInnerOperator : ISpanOperator<TInnerSource, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, GroupJoinOperator<T, T, IdentityOperator<T>, TInner, TKey, TResult, TComparer>.Create(new(), inner, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }

    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TResult, GroupJoinOperator<TSource, TOut, TOperator, TInner, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<TInner, TKey, TResult>(ReadOnlySpan<TInner> inner, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, IEnumerable<TInner>, TResult> resultSelector)
        {
            return new(Source, new(Operator, inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, TResult, GroupJoinOperator<TSource, TOut, TOperator, TInner, TKey, TResult, TComparer>> GroupJoin<TInner, TKey, TResult, TComparer>(ReadOnlySpan<TInner> inner, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, inner, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }

        public SpanEnumerator<TSource, TResult, GroupJoinOperator<TSource, TOut, TOperator, TInner, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<TInnerSource, TInnerOperator, TInner, TKey, TResult>(SpanEnumerator<TInnerSource, TInner, TInnerOperator> inner, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, IEnumerable<TInner>, TResult> resultSelector)
            where TInnerOperator : ISpanOperator<TInnerSource, TInner>
        {
            return new(Source, GroupJoinOperator<TSource, TOut, TOperator, TInner, TKey, TResult, EqualityComparer<TKey>>.Create(Operator, inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, TResult, GroupJoinOperator<TSource, TOut, TOperator, TInner, TKey, TResult, TComparer>> GroupJoin<TInnerSource, TInnerOperator, TInner, TKey, TResult, TComparer>(SpanEnumerator<TInnerSource, TInner, TInnerOperator> inner, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TInnerOperator : ISpanOperator<TInnerSource, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, GroupJoinOperator<TSource, TOut, TOperator, TInner, TKey, TResult, TComparer>.Create(Operator, inner, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }
    }

    public struct GroupJoinOperator<TSpan, TOuter, TOperator, TInner, TKey, TResult, TComparer> : ISpanOperator<TSpan, TResult>, IDisposable
        where TOperator : ISpanOperator<TSpan, TOuter>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator Operator;
        internal readonly Func<TOuter, TKey> OuterKeySelector;
        internal readonly Func<TInner, TKey> InnerKeySelector;
        internal readonly Func<TOuter, IEnumerable<TInner>, TResult> ResultSelector;
        internal readonly TComparer Comparer;

        internal TOuter[] OuterArray;
        internal int OuterArrayLength;
        internal int OuterArrayIndex;
        internal TInner[] InnerArray;
        internal int InnerArrayLength;
#nullable disable   // TODO: avoid CS8714
        internal ArrayPoolDictionary<TKey, ArrayPoolList<TInner>> Dictionary;
#nullable restore
        internal ArrayPoolList<TInner>? NullList;

        private GroupJoinOperator(TOperator op, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
        {
            Operator = op;
            OuterKeySelector = outerKeySelector;
            InnerKeySelector = innerKeySelector;
            ResultSelector = resultSelector;
            Comparer = comparer;

            OuterArray = null!;
            OuterArrayLength = -1;
            OuterArrayIndex = -1;
            InnerArray = null!;
            InnerArrayLength = -1;
            Dictionary = null;
            NullList = null;
        }

        internal GroupJoinOperator(TOperator op, ReadOnlySpan<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            : this(op, outerKeySelector, innerKeySelector, resultSelector, comparer)
        {
            InnerArray = ArrayPool<TInner>.Shared.Rent(inner.Length);
            inner.CopyTo(InnerArray.AsSpan());
            InnerArrayLength = inner.Length;
        }

        internal static GroupJoinOperator<TSpan, TOuter, TOperator, TInner, TKey, TResult, TComparer> Create<TInnerSpan, TInnerOperator>(
            TOperator op, SpanEnumerator<TInnerSpan, TInner, TInnerOperator> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TInnerOperator : ISpanOperator<TInnerSpan, TInner>
        {
            var result = new GroupJoinOperator<TSpan, TOuter, TOperator, TInner, TKey, TResult, TComparer>(op, outerKeySelector, innerKeySelector, resultSelector, comparer);
            var innerSpan = inner.ToArrayPool(out result.InnerArray);
            result.InnerArrayLength = innerSpan.Length;

            return result;
        }

        private void Create(ref ReadOnlySpan<TSpan> source, ReadOnlySpan<TInner> inner)
        {
            Dictionary = new(Comparer);

            var outerSpan = SpanEnumerator<TSpan, TOuter, TOperator>.ToArrayPool(source, Operator, out OuterArray);
            OuterArrayLength = outerSpan.Length;
            OuterArrayIndex = 0;

            foreach (var outer in outerSpan)
            {
                var outerKey = OuterKeySelector(outer);
                if (outerKey == null)
                {
                    NullList ??= new(0);
                }
                else
                {
                    Dictionary.TryAdd(outerKey, new(0));
                }
            }

            for (int i = 0; i < inner.Length; i++)
            {
                var current = inner[i];

                var innerKey = InnerKeySelector(current);
                if (innerKey == null)
                {
                    NullList?.Add(current);
                }
                else
                {
                    if (Dictionary.TryGetValue(innerKey, out var values))
                    {
                        values.Add(current);
                    }
                }
            }
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TResult TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (OuterArrayIndex == -1)
            {
                Create(ref source, InnerArray.AsSpan(..InnerArrayLength));
            }

            if (OuterArrayIndex < OuterArrayLength)
            {
                var outerKey = OuterKeySelector(OuterArray[OuterArrayIndex]);
                var result = ResultSelector(OuterArray[OuterArrayIndex], outerKey == null ? NullList! : Dictionary![outerKey]);
                OuterArrayIndex++;
                success = true;
                return result;
            }
            else if (OuterArrayIndex > 0)
            {
                Dispose();
            }

            success = false;
            return default!;
        }

        public void Dispose()
        {
            ArrayPool<TOuter>.Shared.Return(OuterArray);
            ArrayPool<TInner>.Shared.Return(InnerArray);
            Dictionary?.Dispose();
            NullList?.Dispose();
            OuterArrayIndex = int.MinValue;
        }
    }
}
