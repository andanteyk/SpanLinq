namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator2<TOuter, TSource2, TResult, JoinOperator<TOuter, TSource2, TResult, IdentityOperator<TOuter>, TOperator2, TOuter, TInner, TKey, EqualityComparer<TKey>>> Join<TSource2, TOperator2, TOuter, TInner, TResult, TKey>(this ReadOnlySpan<TOuter> span, SpanEnumerator<TSource2, TInner, TOperator2> second, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TInner>
        {
            return new(span, second.Source, new(new(), second.Operator, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TOuter, TInner, TResult, JoinOperator<TOuter, TInner, TResult, IdentityOperator<TOuter>, IdentityOperator<TInner>, TOuter, TInner, TKey, EqualityComparer<TKey>>> Join<TOuter, TInner, TResult, TKey>(this ReadOnlySpan<TOuter> span, ReadOnlySpan<TInner> second, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            return new(span, second, new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TOuter, TSource2, TResult, JoinOperator<TOuter, TSource2, TResult, IdentityOperator<TOuter>, TOperator2, TOuter, TInner, TKey, TComparer>> Join<TSource2, TOperator2, TOuter, TInner, TResult, TKey, TComparer>(this ReadOnlySpan<TOuter> span, SpanEnumerator<TSource2, TInner, TOperator2> second, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second.Source, new(new(), second.Operator, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }

        public static SpanEnumerator2<TOuter, TInner, TResult, JoinOperator<TOuter, TInner, TResult, IdentityOperator<TOuter>, IdentityOperator<TInner>, TOuter, TInner, TKey, TComparer>> Join<TOuter, TInner, TResult, TKey, TComparer>(this ReadOnlySpan<TOuter> span, ReadOnlySpan<TInner> second, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second, new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, comparer));
        }


        public static SpanEnumerator2<TOuter, TSource2, TResult, JoinOperator<TOuter, TSource2, TResult, IdentityOperator<TOuter>, TOperator2, TOuter, TInner, TKey, EqualityComparer<TKey>>> Join<TSource2, TOperator2, TOuter, TInner, TResult, TKey>(this Span<TOuter> span, SpanEnumerator<TSource2, TInner, TOperator2> second, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TInner>
        {
            return new(span, second.Source, new(new(), second.Operator, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TOuter, TInner, TResult, JoinOperator<TOuter, TInner, TResult, IdentityOperator<TOuter>, IdentityOperator<TInner>, TOuter, TInner, TKey, EqualityComparer<TKey>>> Join<TOuter, TInner, TResult, TKey>(this Span<TOuter> span, ReadOnlySpan<TInner> second, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            return new(span, second, new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator2<TOuter, TSource2, TResult, JoinOperator<TOuter, TSource2, TResult, IdentityOperator<TOuter>, TOperator2, TOuter, TInner, TKey, TComparer>> Join<TSource2, TOperator2, TOuter, TInner, TResult, TKey, TComparer>(this Span<TOuter> span, SpanEnumerator<TSource2, TInner, TOperator2> second, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second.Source, new(new(), second.Operator, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }

        public static SpanEnumerator2<TOuter, TInner, TResult, JoinOperator<TOuter, TInner, TResult, IdentityOperator<TOuter>, IdentityOperator<TInner>, TOuter, TInner, TKey, TComparer>> Join<TOuter, TInner, TResult, TKey, TComparer>(this Span<TOuter> span, ReadOnlySpan<TInner> second, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, second, new(new(), new(), outerKeySelector, innerKeySelector, resultSelector, comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator2<TSource, TSource2, TResult, JoinOperator<TSource, TSource2, TResult, TOperator, TOperator2, TOut, TInner, TKey, EqualityComparer<TKey>>> Join<TSource2, TOperator2, TInner, TKey, TResult>(SpanEnumerator<TSource2, TInner, TOperator2> second, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, TInner, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TInner>
        {
            return new(Source, second.Source, new(Operator, second.Operator, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator2<TSource, TInner, TResult, JoinOperator<TSource, TInner, TResult, TOperator, IdentityOperator<TInner>, TOut, TInner, TKey, EqualityComparer<TKey>>> Join<TInner, TKey, TResult>(ReadOnlySpan<TInner> second, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, TInner, TResult> resultSelector)
        {
            return new(Source, second, new(Operator, new IdentityOperator<TInner>(), outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator2<TSource, TSource2, TResult, JoinOperator<TSource, TSource2, TResult, TOperator, TOperator2, TOut, TInner, TKey, TComparer>> Join<TSource2, TOperator2, TInner, TKey, TResult, TComparer>(SpanEnumerator<TSource2, TInner, TOperator2> second, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, TInner, TResult> resultSelector, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TInner>
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, second.Source, new(Operator, second.Operator, outerKeySelector, innerKeySelector, resultSelector, comparer));
        }

        public SpanEnumerator2<TSource, TInner, TResult, JoinOperator<TSource, TInner, TResult, TOperator, IdentityOperator<TInner>, TOut, TInner, TKey, TComparer>> Join<TInner, TKey, TResult, TComparer>(ReadOnlySpan<TInner> second, Func<TOut, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOut, TInner, TResult> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, second, new(Operator, new IdentityOperator<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer));
        }
    }

    public struct JoinOperator<TSpan1, TSpan2, TResult, TOperator1, TOperator2, TOuter, TInner, TKey, TComparer> : ISpanOperator2<TSpan1, TSpan2, TResult>, IDisposable
        where TOperator1 : ISpanOperator<TSpan1, TOuter>
        where TOperator2 : ISpanOperator<TSpan2, TInner>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal Func<TOuter, TKey> OuterKeySelector;
        internal Func<TInner, TKey> InnerKeySelector;
        internal Func<TOuter, TInner, TResult> ResultSelector;
        internal readonly TComparer Comparer;
#nullable disable   // TODO: avoid CS8714
        internal ArrayPoolDictionary<TKey, ArrayPoolList<TInner>> Dictionary;
#nullable restore
        internal TOuter CurrentOuter;
        internal ArrayPoolList<TInner>? CurrentInners;

        internal JoinOperator(TOperator1 operator1, TOperator2 operator2, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, TComparer comparer)
        {
            Operator1 = operator1;
            Operator2 = operator2;
            OuterKeySelector = outerKeySelector;
            InnerKeySelector = innerKeySelector;
            ResultSelector = resultSelector;
            Comparer = comparer;
            Dictionary = null;
            CurrentOuter = default!;
            CurrentInners = null;
        }

        public void Dispose()
        {
            Dictionary?.Dispose();
            CurrentInners?.Dispose();
            CurrentInners = null;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan1> source1, ReadOnlySpan<TSpan2> source2, out int length)
        {
            length = default;
            return false;
        }

        public TResult TryMoveNext(ref ReadOnlySpan<TSpan1> source1, ref ReadOnlySpan<TSpan2> source2, out bool success)
        {
            bool ok;

            if (Dictionary == null)
            {
                Dictionary = new(Comparer);
                CurrentInners = new(0);

                while (true)
                {
                    var current2 = Operator2.TryMoveNext(ref source2, out ok);
                    if (!ok)
                    {
                        break;
                    }
                    var current2Key = InnerKeySelector(current2);

                    if (Dictionary.TryGetValue(current2Key, out var list))
                    {
                        list.Add(current2);
                    }
                    else
                    {
                        Dictionary[current2Key] = new(0) { current2 };
                    }
                }
            }

            if (CurrentInners == null)
            {
                success = false;
                return default!;
            }

            if (CurrentInners.Count == 0)
            {
                while (true)
                {
                    var current1 = Operator1.TryMoveNext(ref source1, out ok);
                    if (!ok)
                    {
                        Dispose();
                        success = false;
                        return default!;
                    }
                    var current1Key = OuterKeySelector(current1);

                    if (Dictionary.TryGetValue(current1Key, out var list))
                    {
                        CurrentOuter = current1;
                        CurrentInners.AddRange(list);
                        break;
                    }
                }
            }

            var result = ResultSelector(CurrentOuter, CurrentInners[0]);
            CurrentInners.RemoveAt(0);
            success = true;
            return result;
        }
    }
}
