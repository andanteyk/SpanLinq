namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator2<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TSource1, TSource2, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<TSource1, TSource2, TKey, TResult>(this ReadOnlySpan<TSource1> span, ReadOnlySpan<TSource2> inner, Func<TSource1, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TSource1, IEnumerable<TSource2>, TResult> resultSelector)
        {
            return new(span, inner, new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TSource1, TSource2, TKey, TResult, TComparer>> GroupJoin<TSource1, TSource2, TKey, TResult, TComparer>(this ReadOnlySpan<TSource1> span, ReadOnlySpan<TSource2> inner, Func<TSource1, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TSource1, IEnumerable<TSource2>, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, inner, new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, comparer));
        }

        public static SpanEnumerator2<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, TOperator2, TSource1, TInner, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<TSource1, TSource2, TOperator2, TInner, TKey, TResult>(this ReadOnlySpan<TSource1> span, SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TSource1, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource1, IEnumerable<TInner>, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TInner>
        {
            return new(span, inner.Source, new(new(), inner.Operator, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, TOperator2, TSource1, TInner, TKey, TResult, TComparer>> GroupJoin<TSource1, TSource2, TOperator2, TInner, TKey, TResult, TComparer>(this ReadOnlySpan<TSource1> span, SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TSource1, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource1, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, inner.Source, new(new(), inner.Operator, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }


        public static SpanEnumerator2<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TSource1, TSource2, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<TSource1, TSource2, TKey, TResult>(this Span<TSource1> span, ReadOnlySpan<TSource2> inner, Func<TSource1, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TSource1, IEnumerable<TSource2>, TResult> resultSelector)
        {
            return new(span, inner, new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TSource1, TSource2, TKey, TResult, TComparer>> GroupJoin<TSource1, TSource2, TKey, TResult, TComparer>(this Span<TSource1> span, ReadOnlySpan<TSource2> inner, Func<TSource1, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TSource1, IEnumerable<TSource2>, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, inner, new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, comparer));
        }

        public static SpanEnumerator2<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, TOperator2, TSource1, TInner, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<TSource1, TSource2, TOperator2, TInner, TKey, TResult>(this Span<TSource1> span, SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TSource1, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource1, IEnumerable<TInner>, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TInner>
        {
            return new(span, inner.Source, new(new(), inner.Operator, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TSource1, TSource2, TResult, GroupJoinOperator<TSource1, TSource2, IdentityOperator<TSource1>, TOperator2, TSource1, TInner, TKey, TResult, TComparer>> GroupJoin<TSource1, TSource2, TOperator2, TInner, TKey, TResult, TComparer>(this Span<TSource1> span, SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TSource1, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource1, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, inner.Source, new(new(), inner.Operator, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator2<TSource, TSource2, TResult, GroupJoinOperator<TSource, TSource2, TOperator, IdentityOperator<TSource2>, TOut, TSource2, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<TSource2, TKey, TResult>(ReadOnlySpan<TSource2> inner, Func<TOut, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TOut, IEnumerable<TSource2>, TResult> resultSelector)
        {
            return new(Source, inner, new(Operator, new(), outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator2<TSource, TSource2, TResult, GroupJoinOperator<TSource, TSource2, TOperator, IdentityOperator<TSource2>, TOut, TSource2, TKey, TResult, TComparer>> GroupJoin<TSource2, TKey, TResult, TComparer>(ReadOnlySpan<TSource2> inner, Func<TOut, TKey> outerKeySelector, Func<TSource2, TKey> innerKeySelector, Func<TOut, IEnumerable<TSource2>, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, inner, new(Operator, new(), outerKeySelector, innerKeySelector, resultSelector, comparer));
        }

        public SpanEnumerator2<TSource, TSource2, TResult, GroupJoinOperator<TSource, TSource2, TOperator, TOperator2, TOut, TInner, TKey, TResult, EqualityComparer<TKey>>> GroupJoin<TSource2, TOperator2, TInner, TKey, TResult>(SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, IEnumerable<TInner>, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TInner>
        {
            return new(Source, inner.Source, new(Operator, inner.Operator, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator2<TSource, TSource2, TResult, GroupJoinOperator<TSource, TSource2, TOperator, TOperator2, TOut, TInner, TKey, TResult, TComparer>> GroupJoin<TSource2, TOperator2, TInner, TKey, TResult, TComparer>(SpanEnumerator<TSource2, TInner, TOperator2> inner, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, inner.Source, new(Operator, inner.Operator, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }
    }

    public struct GroupJoinOperator<TSpan1, TSpan2, TOperator1, TOperator2, TOuter, TInner, TKey, TResult, TComparer> : ISpanOperator2<TSpan1, TSpan2, TResult>, IDisposable
        where TOperator1 : ISpanOperator<TSpan1, TOuter>
        where TOperator2 : ISpanOperator<TSpan2, TInner>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal readonly Func<TOuter, TKey> OuterKeySelector;
        internal readonly Func<TInner, TKey> InnerKeySelector;
        internal readonly Func<TOuter, IEnumerable<TInner>, TResult> ResultSelector;
        internal readonly TComparer Comparer;

#nullable disable   // TODO: avoid CS8714
        internal ArrayPoolDictionary<TKey, ArrayPoolList<TInner>> Dictionary;
#nullable restore
        internal ArrayPoolList<TInner>? NullList;

        internal GroupJoinOperator(TOperator1 op1, TOperator2 op2, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, TComparer comparer)
        {
            Operator1 = op1;
            Operator2 = op2;
            OuterKeySelector = outerKeySelector;
            InnerKeySelector = innerKeySelector;
            ResultSelector = resultSelector;
            Comparer = comparer;

            Dictionary = null;
            NullList = null;
        }

        private void CreateDictionary(ref ReadOnlySpan<TSpan2> source2)
        {
            Dictionary = new(Comparer);

            while (true)
            {
                var current2 = Operator2.TryMoveNext(ref source2, out bool ok);
                if (!ok)
                {
                    break;
                }

                var current2Key = InnerKeySelector(current2);
                if (current2Key == null)
                {
                    NullList ??= new();
                    NullList.Add(current2);
                }
                else
                {
                    if (Dictionary.ContainsKey(current2Key))
                    {
                        Dictionary[current2Key].Add(current2);
                    }
                    else
                    {
                        Dictionary[current2Key] = new() { current2 };
                    }
                }
            }
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan1> source1, ReadOnlySpan<TSpan2> source2, out int length)
        {
            return Operator1.TryGetNonEnumeratedCount(source1, out length);
        }

        public TResult TryMoveNext(ref ReadOnlySpan<TSpan1> source1, ref ReadOnlySpan<TSpan2> source2, out bool success)
        {
            if (Dictionary == null)
            {
                CreateDictionary(ref source2);
            }

            var current1 = Operator1.TryMoveNext(ref source1, out bool ok);
            if (!ok)
            {
                Dispose();
                success = false;
                return default!;
            }

            var current1Key = OuterKeySelector(current1);

            if (current1Key == null)
            {
                success = true;
                if (NullList != null)
                {
                    return ResultSelector(current1, NullList);
                }
                else
                {
                    return ResultSelector(current1, Array.Empty<TInner>());
                }
            }
            else
            {
                success = true;
                if (Dictionary!.TryGetValue(current1Key, out var list))
                {
                    return ResultSelector(current1, list);
                }
                else
                {
                    return ResultSelector(current1, Array.Empty<TInner>());
                }
            }
        }

        public void Dispose()
        {
            foreach (var pair in Dictionary)
            {
                pair.Value.Dispose();
            }
            Dictionary?.Dispose();
            NullList?.Dispose();
            NullList = null;
        }
    }
}
