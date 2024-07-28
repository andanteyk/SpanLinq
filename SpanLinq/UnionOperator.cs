namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator2<TIn, TSource2, TIn, UnionOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, EqualityComparer<TIn>>> Union<TIn, TSource2, TOperator2>(this ReadOnlySpan<TIn> span, SpanEnumerator<TSource2, TIn, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TIn>
        {
            return new(span, second.Source, new(new(), second.Operator, EqualityComparer<TIn>.Default));
        }

        public static SpanEnumerator2<TIn, TIn, TIn, UnionOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, EqualityComparer<TIn>>> Union<TIn>(this ReadOnlySpan<TIn> span, ReadOnlySpan<TIn> second)
        {
            return new(span, second, new(new(), new(), EqualityComparer<TIn>.Default));
        }

        public static SpanEnumerator2<TIn, TSource2, TIn, UnionOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TComparer>> Union<TIn, TSource2, TOperator2, TComparer>(this ReadOnlySpan<TIn> span, SpanEnumerator<TSource2, TIn, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TIn>
            where TComparer : IEqualityComparer<TIn>
        {
            return new(span, second.Source, new(new(), second.Operator, comparer));
        }

        public static SpanEnumerator2<TIn, TIn, TIn, UnionOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TComparer>> Union<TIn, TComparer>(this ReadOnlySpan<TIn> span, ReadOnlySpan<TIn> second, TComparer comparer)
            where TComparer : IEqualityComparer<TIn>
        {
            return new(span, second, new(new(), new(), comparer));
        }


        public static SpanEnumerator2<TIn, TSource2, TIn, UnionOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, EqualityComparer<TIn>>> Union<TIn, TSource2, TOperator2>(this Span<TIn> span, SpanEnumerator<TSource2, TIn, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TIn>
        {
            return new(span, second.Source, new(new(), second.Operator, EqualityComparer<TIn>.Default));
        }

        public static SpanEnumerator2<TIn, TIn, TIn, UnionOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, EqualityComparer<TIn>>> Union<TIn>(this Span<TIn> span, ReadOnlySpan<TIn> second)
        {
            return new(span, second, new(new(), new(), EqualityComparer<TIn>.Default));
        }

        public static SpanEnumerator2<TIn, TSource2, TIn, UnionOperator<TIn, TSource2, TIn, IdentityOperator<TIn>, TOperator2, TComparer>> Union<TIn, TSource2, TOperator2, TComparer>(this Span<TIn> span, SpanEnumerator<TSource2, TIn, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TIn>
            where TComparer : IEqualityComparer<TIn>
        {
            return new(span, second.Source, new(new(), second.Operator, comparer));
        }

        public static SpanEnumerator2<TIn, TIn, TIn, UnionOperator<TIn, TIn, TIn, IdentityOperator<TIn>, IdentityOperator<TIn>, TComparer>> Union<TIn, TComparer>(this Span<TIn> span, ReadOnlySpan<TIn> second, TComparer comparer)
            where TComparer : IEqualityComparer<TIn>
        {
            return new(span, second, new(new(), new(), comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator2<TSource, TSource2, TOut, UnionOperator<TSource, TSource2, TOut, TOperator, TOperator2, EqualityComparer<TOut>>> Union<TSource2, TOperator2>(SpanEnumerator<TSource2, TOut, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TOut>
        {
            return new(Source, second.Source, new(Operator, second.Operator, EqualityComparer<TOut>.Default));
        }

        public SpanEnumerator2<TSource, TOut, TOut, UnionOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>, EqualityComparer<TOut>>> Union(ReadOnlySpan<TOut> second)
        {
            return new(Source, second, new(Operator, new IdentityOperator<TOut>(), EqualityComparer<TOut>.Default));
        }

        public SpanEnumerator2<TSource, TSource2, TOut, UnionOperator<TSource, TSource2, TOut, TOperator, TOperator2, TComparer>> Union<TSource2, TOperator2, TComparer>(SpanEnumerator<TSource2, TOut, TOperator2> second, TComparer comparer)
            where TOperator2 : ISpanOperator<TSource2, TOut>
            where TComparer : IEqualityComparer<TOut>
        {
            return new(Source, second.Source, new(Operator, second.Operator, comparer));
        }

        public SpanEnumerator2<TSource, TOut, TOut, UnionOperator<TSource, TOut, TOut, TOperator, IdentityOperator<TOut>, TComparer>> Union<TComparer>(ReadOnlySpan<TOut> second, TComparer comparer)
            where TComparer : IEqualityComparer<TOut>
        {
            return new(Source, second, new(Operator, new IdentityOperator<TOut>(), comparer));
        }
    }

    public struct UnionOperator<TSpan1, TSpan2, TIn, TOperator1, TOperator2, TComparer> : ISpanOperator2<TSpan1, TSpan2, TIn>, IDisposable
        where TOperator1 : ISpanOperator<TSpan1, TIn>
        where TOperator2 : ISpanOperator<TSpan2, TIn>
        where TComparer : IEqualityComparer<TIn>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal readonly TComparer Comparer;
        internal ArrayPoolDictionary<TIn, byte>? Dictionary;
        internal bool ExistsNull;

        internal UnionOperator(TOperator1 operator1, TOperator2 operator2, TComparer comparer)
        {
            Operator1 = operator1;
            Operator2 = operator2;
            Comparer = comparer;
            Dictionary = null;
            ExistsNull = false;
        }

        public void Dispose()
        {
            Dictionary?.Dispose();
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan1> source1, ReadOnlySpan<TSpan2> source2, out int length)
        {
            length = default;
            return false;
        }

        public TIn TryMoveNext(ref ReadOnlySpan<TSpan1> source1, ref ReadOnlySpan<TSpan2> source2, out bool success)
        {
            if (Dictionary == null)
            {
                Dictionary = new(Comparer);
            }

            bool ok;

            do
            {
                var current1 = Operator1.TryMoveNext(ref source1, out ok);
                if (ok)
                {
                    if (current1 == null)
                    {
                        if (!ExistsNull)
                        {
                            ExistsNull = true;
                            success = true;
                            return current1;
                        }
                    }
                    else
                    {
                        if (!Dictionary.TryGetValue(current1, out _))
                        {
                            Dictionary.Add(current1, default);
                            success = true;
                            return current1;
                        }
                    }
                }
            } while (ok);

            do
            {
                var current2 = Operator2.TryMoveNext(ref source2, out ok);
                if (ok)
                {
                    if (current2 == null)
                    {
                        if (!ExistsNull)
                        {
                            ExistsNull = true;
                            success = true;
                            return current2;
                        }
                    }
                    else
                    {
                        if (!Dictionary.TryGetValue(current2, out _))
                        {
                            Dictionary.Add(current2, default);
                            success = true;
                            return current2;
                        }
                    }
                }
            } while (ok);


            Dispose();
            success = false;
            return default!;
        }
    }
}
