namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator3<TSource1, TSource2, TSource3, (TSource1 First, TSource2 Second, TSource3 Third), ZipOperator<TSource1, TSource2, TSource3, TSource1, TSource2, TSource3, IdentityOperator<TSource1>, IdentityOperator<TSource2>, IdentityOperator<TSource3>>> Zip<TSource1, TSource2, TSource3>(this ReadOnlySpan<TSource1> span, ReadOnlySpan<TSource2> second, ReadOnlySpan<TSource3> third)
        {
            return new(span, second, third, new(new(), new(), new()));
        }

        public static SpanEnumerator3<TSource1, TSource2, TSource3, (TSource1 First, TSource2 Second, TOut3 Third), ZipOperator<TSource1, TSource2, TSource3, TSource1, TSource2, TOut3, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TOperator3>> Zip<TSource1, TSource2, TSource3, TOut3, TOperator3>(this ReadOnlySpan<TSource1> span, ReadOnlySpan<TSource2> second, SpanEnumerator<TSource3, TOut3, TOperator3> third)
            where TOperator3 : ISpanOperator<TSource3, TOut3>
        {
            return new(span, second, third.Source, new(new(), new(), third.Operator));
        }

        public static SpanEnumerator3<TSource1, TSource2, TSource3, (TSource1 First, TOut2 Second, TSource3 Third), ZipOperator<TSource1, TSource2, TSource3, TSource1, TOut2, TSource3, IdentityOperator<TSource1>, TOperator2, IdentityOperator<TSource3>>> Zip<TSource1, TSource2, TSource3, TOut2, TOperator2>(this ReadOnlySpan<TSource1> span, SpanEnumerator<TSource2, TOut2, TOperator2> second, ReadOnlySpan<TSource3> third)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
        {
            return new(span, second.Source, third, new(new(), second.Operator, new()));
        }

        public static SpanEnumerator3<TSource1, TSource2, TSource3, (TSource1 First, TOut2 Second, TOut3 Third), ZipOperator<TSource1, TSource2, TSource3, TSource1, TOut2, TOut3, IdentityOperator<TSource1>, TOperator2, TOperator3>> Zip<TSource1, TSource2, TSource3, TOut2, TOut3, TOperator2, TOperator3>(this ReadOnlySpan<TSource1> span, SpanEnumerator<TSource2, TOut2, TOperator2> second, SpanEnumerator<TSource3, TOut3, TOperator3> third)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
            where TOperator3 : ISpanOperator<TSource3, TOut3>
        {
            return new(span, second.Source, third.Source, new(new(), second.Operator, third.Operator));
        }


        public static SpanEnumerator3<TSource1, TSource2, TSource3, (TSource1 First, TSource2 Second, TSource3 Third), ZipOperator<TSource1, TSource2, TSource3, TSource1, TSource2, TSource3, IdentityOperator<TSource1>, IdentityOperator<TSource2>, IdentityOperator<TSource3>>> Zip<TSource1, TSource2, TSource3>(this Span<TSource1> span, ReadOnlySpan<TSource2> second, ReadOnlySpan<TSource3> third)
        {
            return new(span, second, third, new(new(), new(), new()));
        }

        public static SpanEnumerator3<TSource1, TSource2, TSource3, (TSource1 First, TSource2 Second, TOut3 Third), ZipOperator<TSource1, TSource2, TSource3, TSource1, TSource2, TOut3, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TOperator3>> Zip<TSource1, TSource2, TSource3, TOut3, TOperator3>(this Span<TSource1> span, ReadOnlySpan<TSource2> second, SpanEnumerator<TSource3, TOut3, TOperator3> third)
            where TOperator3 : ISpanOperator<TSource3, TOut3>
        {
            return new(span, second, third.Source, new(new(), new(), third.Operator));
        }

        public static SpanEnumerator3<TSource1, TSource2, TSource3, (TSource1 First, TOut2 Second, TSource3 Third), ZipOperator<TSource1, TSource2, TSource3, TSource1, TOut2, TSource3, IdentityOperator<TSource1>, TOperator2, IdentityOperator<TSource3>>> Zip<TSource1, TSource2, TSource3, TOut2, TOperator2>(this Span<TSource1> span, SpanEnumerator<TSource2, TOut2, TOperator2> second, ReadOnlySpan<TSource3> third)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
        {
            return new(span, second.Source, third, new(new(), second.Operator, new()));
        }

        public static SpanEnumerator3<TSource1, TSource2, TSource3, (TSource1 First, TOut2 Second, TOut3 Third), ZipOperator<TSource1, TSource2, TSource3, TSource1, TOut2, TOut3, IdentityOperator<TSource1>, TOperator2, TOperator3>> Zip<TSource1, TSource2, TSource3, TOut2, TOut3, TOperator2, TOperator3>(this Span<TSource1> span, SpanEnumerator<TSource2, TOut2, TOperator2> second, SpanEnumerator<TSource3, TOut3, TOperator3> third)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
            where TOperator3 : ISpanOperator<TSource3, TOut3>
        {
            return new(span, second.Source, third.Source, new(new(), second.Operator, third.Operator));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator3<TSource, TSource2, TSource3, (TOut First, TSource2 Second, TSource3 Third), ZipOperator<TSource, TSource2, TSource3, TOut, TSource2, TSource3, TOperator, IdentityOperator<TSource2>, IdentityOperator<TSource3>>> Zip<TSource2, TSource3>(ReadOnlySpan<TSource2> second, ReadOnlySpan<TSource3> third)
        {
            return new(Source, second, third, new(Operator, new(), new()));
        }

        public SpanEnumerator3<TSource, TSource2, TSource3, (TOut First, TSource2 Second, TOut3 Third), ZipOperator<TSource, TSource2, TSource3, TOut, TSource2, TOut3, TOperator, IdentityOperator<TSource2>, TOperator3>> Zip<TSource2, TSource3, TOut3, TOperator3>(ReadOnlySpan<TSource2> second, SpanEnumerator<TSource3, TOut3, TOperator3> third)
            where TOperator3 : ISpanOperator<TSource3, TOut3>
        {
            return new(Source, second, third.Source, new(Operator, new(), third.Operator));
        }

        public SpanEnumerator3<TSource, TSource2, TSource3, (TOut First, TOut2 Second, TSource3 Third), ZipOperator<TSource, TSource2, TSource3, TOut, TOut2, TSource3, TOperator, TOperator2, IdentityOperator<TSource3>>> Zip<TSource2, TSource3, TOut2, TOperator2>(SpanEnumerator<TSource2, TOut2, TOperator2> second, ReadOnlySpan<TSource3> third)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
        {
            return new(Source, second.Source, third, new(Operator, second.Operator, new()));
        }

        public SpanEnumerator3<TSource, TSource2, TSource3, (TOut First, TOut2 Second, TOut3 Third), ZipOperator<TSource, TSource2, TSource3, TOut, TOut2, TOut3, TOperator, TOperator2, TOperator3>> Zip<TSource2, TSource3, TOut2, TOut3, TOperator2, TOperator3>(SpanEnumerator<TSource2, TOut2, TOperator2> second, SpanEnumerator<TSource3, TOut3, TOperator3> third)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
            where TOperator3 : ISpanOperator<TSource3, TOut3>
        {
            return new(Source, second.Source, third.Source, new(Operator, second.Operator, third.Operator));
        }
    }

    public struct ZipOperator<TSpan1, TSpan2, TSpan3, TIn1, TIn2, TIn3, TOperator1, TOperator2, TOperator3> : ISpanOperator3<TSpan1, TSpan2, TSpan3, (TIn1 First, TIn2 Second, TIn3 Third)>
        where TOperator1 : ISpanOperator<TSpan1, TIn1>
        where TOperator2 : ISpanOperator<TSpan2, TIn2>
        where TOperator3 : ISpanOperator<TSpan3, TIn3>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal TOperator3 Operator3;

        internal ZipOperator(TOperator1 operator1, TOperator2 operator2, TOperator3 operator3)
        {
            Operator1 = operator1;
            Operator2 = operator2;
            Operator3 = operator3;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan1> source1, ReadOnlySpan<TSpan2> source2, ReadOnlySpan<TSpan3> source3, out int length)
        {
            if (Operator1.TryGetNonEnumeratedCount(source1, out int length1) &&
                Operator2.TryGetNonEnumeratedCount(source2, out int length2) &&
                Operator3.TryGetNonEnumeratedCount(source3, out int length3))
            {
                length = Math.Min(length1, Math.Min(length2, length3));
                return true;
            }
            length = default;
            return false;
        }

        public (TIn1 First, TIn2 Second, TIn3 Third) TryMoveNext(ref ReadOnlySpan<TSpan1> source1, ref ReadOnlySpan<TSpan2> source2, ref ReadOnlySpan<TSpan3> source3, out bool success)
        {
            var current1 = Operator1.TryMoveNext(ref source1, out bool ok1);
            var current2 = Operator2.TryMoveNext(ref source2, out bool ok2);
            var current3 = Operator3.TryMoveNext(ref source3, out bool ok3);

            if (ok1 && ok2 && ok3)
            {
                success = true;
                return (current1, current2, current3);
            }

            success = false;
            return default!;
        }
    }
}
