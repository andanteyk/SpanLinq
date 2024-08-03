using System.ComponentModel.Design;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TSource1, (TSource1 First, TSource2 Second), Convert2Operator<TSource1, TSource2, (TSource1 First, TSource2 Second), ZipOperator<TSource1, TSource2, TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, (TSource1 First, TSource2 Second)>>> Zip<TSource1, TSource2>(this ReadOnlySpan<TSource1> span, ReadOnlySpan<TSource2> second)
        {
            return new(span, new(new(new(), new(), (First, Second) => (First, Second)), second));
        }

        public static SpanEnumerator<TSource1, (TSource1 First, TOut2 Second), Convert2Operator<TSource1, TSource2, (TSource1 First, TOut2 Second), ZipOperator<TSource1, TSource2, TSource1, TOut2, IdentityOperator<TSource1>, TOperator2, (TSource1 First, TOut2 Second)>>> Zip<TSource1, TSource2, TOut2, TOperator2>(this ReadOnlySpan<TSource1> span, SpanEnumerator<TSource2, TOut2, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
        {
            return new(span, new(new(new(), second.Operator, (First, Second) => (First, Second)), second.Source));
        }

        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, ZipOperator<TSource1, TSource2, TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TResult>>> Zip<TSource1, TSource2, TResult>(this ReadOnlySpan<TSource1> span, ReadOnlySpan<TSource2> second, Func<TSource1, TSource2, TResult> resultSelector)
        {
            return new(span, new(new(new(), new(), resultSelector), second));
        }

        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, ZipOperator<TSource1, TSource2, TSource1, TOut2, IdentityOperator<TSource1>, TOperator2, TResult>>> Zip<TSource1, TSource2, TOut2, TOperator2, TResult>(this ReadOnlySpan<TSource1> span, SpanEnumerator<TSource2, TOut2, TOperator2> second, Func<TSource1, TOut2, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
        {
            return new(span, new(new(new(), second.Operator, resultSelector), second.Source));
        }


        public static SpanEnumerator<TSource1, (TSource1 First, TSource2 Second), Convert2Operator<TSource1, TSource2, (TSource1 First, TSource2 Second), ZipOperator<TSource1, TSource2, TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, (TSource1 First, TSource2 Second)>>> Zip<TSource1, TSource2>(this Span<TSource1> span, ReadOnlySpan<TSource2> second)
        {
            return new(span, new(new(new(), new(), (First, Second) => (First, Second)), second));
        }

        public static SpanEnumerator<TSource1, (TSource1 First, TOut2 Second), Convert2Operator<TSource1, TSource2, (TSource1 First, TOut2 Second), ZipOperator<TSource1, TSource2, TSource1, TOut2, IdentityOperator<TSource1>, TOperator2, (TSource1 First, TOut2 Second)>>> Zip<TSource1, TSource2, TOut2, TOperator2>(this Span<TSource1> span, SpanEnumerator<TSource2, TOut2, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
        {
            return new(span, new(new(new(), second.Operator, (First, Second) => (First, Second)), second.Source));
        }

        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, ZipOperator<TSource1, TSource2, TSource1, TSource2, IdentityOperator<TSource1>, IdentityOperator<TSource2>, TResult>>> Zip<TSource1, TSource2, TResult>(this Span<TSource1> span, ReadOnlySpan<TSource2> second, Func<TSource1, TSource2, TResult> resultSelector)
        {
            return new(span, new(new(new(), new(), resultSelector), second));
        }

        public static SpanEnumerator<TSource1, TResult, Convert2Operator<TSource1, TSource2, TResult, ZipOperator<TSource1, TSource2, TSource1, TOut2, IdentityOperator<TSource1>, TOperator2, TResult>>> Zip<TSource1, TSource2, TOut2, TOperator2, TResult>(this Span<TSource1> span, SpanEnumerator<TSource2, TOut2, TOperator2> second, Func<TSource1, TOut2, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
        {
            return new(span, new(new(new(), second.Operator, resultSelector), second.Source));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, (TOut First, TOut2 Second), Convert2Operator<TSource, TSource2, (TOut First, TOut2 Second), ZipOperator<TSource, TSource2, TOut, TOut2, TOperator, TOperator2, (TOut First, TOut2 Second)>>> Zip<TSource2, TOut2, TOperator2>(SpanEnumerator<TSource2, TOut2, TOperator2> second)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
        {
            return new(Source, new(new(Operator, second.Operator, (First, Second) => (First, Second)), second.Source));
        }

        public SpanEnumerator<TSource, TResult, Convert2Operator<TSource, TSource2, TResult, ZipOperator<TSource, TSource2, TOut, TOut2, TOperator, TOperator2, TResult>>> Zip<TSource2, TOut2, TOperator2, TResult>(SpanEnumerator<TSource2, TOut2, TOperator2> second, Func<TOut, TOut2, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSource2, TOut2>
        {
            return new(Source, new(new(Operator, second.Operator, resultSelector), second.Source));
        }

        public SpanEnumerator<TSource, (TOut First, TOut2 Second), Convert2Operator<TSource, TOut2, (TOut First, TOut2 Second), ZipOperator<TSource, TOut2, TOut, TOut2, TOperator, IdentityOperator<TOut2>, (TOut First, TOut2 Second)>>> Zip<TOut2, TResult>(ReadOnlySpan<TOut2> second)
        {
            return new(Source, new(new(Operator, new(), static (First, Second) => (First, Second)), second));
        }

        public SpanEnumerator<TSource, TResult, Convert2Operator<TSource, TOut2, TResult, ZipOperator<TSource, TOut2, TOut, TOut2, TOperator, IdentityOperator<TOut2>, TResult>>> Zip<TOut2, TResult>(ReadOnlySpan<TOut2> second, Func<TOut, TOut2, TResult> resultSelector)
        {
            return new(Source, new(new(Operator, new(), resultSelector), second));
        }
    }

    public struct ZipOperator<TSpan1, TSpan2, TIn1, TIn2, TOperator1, TOperator2, TResult> : ISpanOperator2<TSpan1, TSpan2, TResult>
        where TOperator1 : ISpanOperator<TSpan1, TIn1>
        where TOperator2 : ISpanOperator<TSpan2, TIn2>
    {
        internal TOperator1 Operator1;
        internal TOperator2 Operator2;
        internal Func<TIn1, TIn2, TResult> ResultSelector;

        internal ZipOperator(TOperator1 operator1, TOperator2 operator2, Func<TIn1, TIn2, TResult> resultSelector)
        {
            Operator1 = operator1;
            Operator2 = operator2;
            ResultSelector = resultSelector;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan1> source1, ReadOnlySpan<TSpan2> source2, out int length)
        {
            if (Operator1.TryGetNonEnumeratedCount(source1, out int length1) && Operator2.TryGetNonEnumeratedCount(source2, out int length2))
            {
                length = Math.Min(length1, length2);
                return true;
            }
            length = default;
            return false;
        }

        public TResult TryMoveNext(ref ReadOnlySpan<TSpan1> source1, ref ReadOnlySpan<TSpan2> source2, out bool success)
        {
            var current1 = Operator1.TryMoveNext(ref source1, out bool ok1);
            var current2 = Operator2.TryMoveNext(ref source2, out bool ok2);

            if (ok1 && ok2)
            {
                success = true;
                return ResultSelector(current1, current2);
            }

            success = false;
            return default!;
        }
    }
}
