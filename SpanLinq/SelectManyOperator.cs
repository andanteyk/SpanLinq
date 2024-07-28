using System.Buffers;
using Dia2Lib;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>> SelectMany<TIn, TOut, TSpan2, TOperator2>(this ReadOnlySpan<TIn> span, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>.CollectionSelectorDelegate selector)
            where TOperator2 : ISpanOperator<TSpan2, TOut>
        {
            return new(span, new(new(), (input, _) => selector(input), (tOut, tCollection) => tCollection));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>> SelectMany<TIn, TOut, TSpan2, TOperator2>(this ReadOnlySpan<TIn> span, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>.CollectionWithIndexSelectorDelegate selector)
            where TOperator2 : ISpanOperator<TSpan2, TOut>
        {
            return new(span, new(new(), selector, (tOut, tCollection) => tCollection));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>> SelectMany<TIn, TCollection, TOut, TSpan2, TOperator2>(this ReadOnlySpan<TIn> span, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>.CollectionSelectorDelegate collectionSelector, Func<TIn, TCollection, TOut> resultSelector)
            where TOperator2 : ISpanOperator<TSpan2, TCollection>
        {
            return new(span, new(new(), (input, _) => collectionSelector(input), resultSelector));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>> SelectMany<TIn, TCollection, TOut, TSpan2, TOperator2>(this ReadOnlySpan<TIn> span, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>.CollectionWithIndexSelectorDelegate collectionSelector, Func<TIn, TCollection, TOut> resultSelector)
            where TOperator2 : ISpanOperator<TSpan2, TCollection>
        {
            return new(span, new(new(), collectionSelector, resultSelector));
        }


        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TOut, IdentityOperator<TOut>>> SelectMany<TIn, TOut>(this ReadOnlySpan<TIn> span, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TOut, IdentityOperator<TOut>>.SpanCollectionSelectorDelegate collectionSelector)
        {
            return new(span, new(new(), (input, _) => new SpanEnumerator<TOut, TOut, IdentityOperator<TOut>>(collectionSelector(input), new IdentityOperator<TOut>()), (tOut, tCollection) => tCollection));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TOut, IdentityOperator<TOut>>> SelectMany<TIn, TOut>(this ReadOnlySpan<TIn> span, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TOut, IdentityOperator<TOut>>.SpanCollectionWithIndexSelectorDelegate collectionSelector)
        {
            return new(span, new(new(), (input, i) => new SpanEnumerator<TOut, TOut, IdentityOperator<TOut>>(collectionSelector(input, i), new IdentityOperator<TOut>()), (tOut, tCollection) => tCollection));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TCollection, IdentityOperator<TCollection>>> SelectMany<TIn, TCollection, TOut>(this ReadOnlySpan<TIn> span, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TCollection, IdentityOperator<TCollection>>.SpanCollectionSelectorDelegate collectionSelector, Func<TIn, TCollection, TOut> resultSelector)
        {
            return new(span, new(new(), (input, _) => new SpanEnumerator<TCollection, TCollection, IdentityOperator<TCollection>>(collectionSelector(input), new IdentityOperator<TCollection>()), resultSelector));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TCollection, IdentityOperator<TCollection>>> SelectMany<TIn, TCollection, TOut>(this ReadOnlySpan<TIn> span, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TCollection, IdentityOperator<TCollection>>.SpanCollectionWithIndexSelectorDelegate collectionSelector, Func<TIn, TCollection, TOut> resultSelector)
        {
            return new(span, new(new(), (input, i) => new SpanEnumerator<TCollection, TCollection, IdentityOperator<TCollection>>(collectionSelector(input, i), new IdentityOperator<TCollection>()), resultSelector));
        }


        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>> SelectMany<TIn, TOut, TSpan2, TOperator2>(this Span<TIn> span, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>.CollectionSelectorDelegate selector)
            where TOperator2 : ISpanOperator<TSpan2, TOut>
        {
            return new(span, new(new(), (input, _) => selector(input), (tOut, tCollection) => tCollection));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>> SelectMany<TIn, TOut, TSpan2, TOperator2>(this Span<TIn> span, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>.CollectionWithIndexSelectorDelegate selector)
            where TOperator2 : ISpanOperator<TSpan2, TOut>
        {
            return new(span, new(new(), selector, (tOut, tCollection) => tCollection));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>> SelectMany<TIn, TCollection, TOut, TSpan2, TOperator2>(this Span<TIn> span, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>.CollectionSelectorDelegate collectionSelector, Func<TIn, TCollection, TOut> resultSelector)
            where TOperator2 : ISpanOperator<TSpan2, TCollection>
        {
            return new(span, new(new(), (input, _) => collectionSelector(input), resultSelector));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>> SelectMany<TIn, TCollection, TOut, TSpan2, TOperator2>(this Span<TIn> span, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TSpan2, TOperator2>.CollectionWithIndexSelectorDelegate collectionSelector, Func<TIn, TCollection, TOut> resultSelector)
            where TOperator2 : ISpanOperator<TSpan2, TCollection>
        {
            return new(span, new(new(), collectionSelector, resultSelector));
        }


        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TOut, IdentityOperator<TOut>>> SelectMany<TIn, TOut>(this Span<TIn> span, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TOut, IdentityOperator<TOut>>.SpanCollectionSelectorDelegate collectionSelector)
        {
            return new(span, new(new(), (input, _) => new SpanEnumerator<TOut, TOut, IdentityOperator<TOut>>(collectionSelector(input), new IdentityOperator<TOut>()), (tOut, tCollection) => tCollection));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TOut, IdentityOperator<TOut>>> SelectMany<TIn, TOut>(this Span<TIn> span, SelectManyOperator<TIn, TIn, TOut, TOut, IdentityOperator<TIn>, TOut, IdentityOperator<TOut>>.SpanCollectionWithIndexSelectorDelegate collectionSelector)
        {
            return new(span, new(new(), (input, i) => new SpanEnumerator<TOut, TOut, IdentityOperator<TOut>>(collectionSelector(input, i), new IdentityOperator<TOut>()), (tOut, tCollection) => tCollection));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TCollection, IdentityOperator<TCollection>>> SelectMany<TIn, TCollection, TOut>(this Span<TIn> span, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TCollection, IdentityOperator<TCollection>>.SpanCollectionSelectorDelegate collectionSelector, Func<TIn, TCollection, TOut> resultSelector)
        {
            return new(span, new(new(), (input, _) => new SpanEnumerator<TCollection, TCollection, IdentityOperator<TCollection>>(collectionSelector(input), new IdentityOperator<TCollection>()), resultSelector));
        }

        public static SpanEnumerator<TIn, TOut, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TCollection, IdentityOperator<TCollection>>> SelectMany<TIn, TCollection, TOut>(this Span<TIn> span, SelectManyOperator<TIn, TIn, TCollection, TOut, IdentityOperator<TIn>, TCollection, IdentityOperator<TCollection>>.SpanCollectionWithIndexSelectorDelegate collectionSelector, Func<TIn, TCollection, TOut> resultSelector)
        {
            return new(span, new(new(), (input, i) => new SpanEnumerator<TCollection, TCollection, IdentityOperator<TCollection>>(collectionSelector(input, i), new IdentityOperator<TCollection>()), resultSelector));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TResult, SelectManyOperator<TSource, TOut, TResult, TResult, TOperator, TSpan2, TOperator2>> SelectMany<TResult, TSpan2, TOperator2>(SelectManyOperator<TSource, TOut, TResult, TResult, TOperator, TSpan2, TOperator2>.CollectionSelectorDelegate selector)
            where TOperator2 : ISpanOperator<TSpan2, TResult>
        {
            return new(Source, new(Operator, (input, _) => selector(input), (tOut, tCollection) => tCollection));
        }

        public SpanEnumerator<TSource, TResult, SelectManyOperator<TSource, TOut, TResult, TResult, TOperator, TSpan2, TOperator2>> SelectMany<TResult, TSpan2, TOperator2>(SelectManyOperator<TSource, TOut, TResult, TResult, TOperator, TSpan2, TOperator2>.CollectionWithIndexSelectorDelegate selector)
            where TOperator2 : ISpanOperator<TSpan2, TResult>
        {
            return new(Source, new(Operator, selector, (tOut, tCollection) => tCollection));
        }

        public SpanEnumerator<TSource, TResult, SelectManyOperator<TSource, TOut, TCollection, TResult, TOperator, TSpan2, TOperator2>> SelectMany<TCollection, TResult, TSpan2, TOperator2>(SelectManyOperator<TSource, TOut, TCollection, TResult, TOperator, TSpan2, TOperator2>.CollectionSelectorDelegate collectionSelector, Func<TOut, TCollection, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSpan2, TCollection>
        {
            return new(Source, new(Operator, (input, _) => collectionSelector(input), resultSelector));
        }

        public SpanEnumerator<TSource, TResult, SelectManyOperator<TSource, TOut, TCollection, TResult, TOperator, TSpan2, TOperator2>> SelectMany<TCollection, TResult, TSpan2, TOperator2>(SelectManyOperator<TSource, TOut, TCollection, TResult, TOperator, TSpan2, TOperator2>.CollectionWithIndexSelectorDelegate collectionSelector, Func<TOut, TCollection, TResult> resultSelector)
            where TOperator2 : ISpanOperator<TSpan2, TCollection>
        {
            return new(Source, new(Operator, collectionSelector, resultSelector));
        }
    }

    public struct SelectManyOperator<TSpan, TIn, TCollection, TOut, TOperator, TSpan2, TOperator2> : ISpanOperator<TSpan, TOut>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TOperator2 : ISpanOperator<TSpan2, TCollection>
    {
        internal TOperator Operator;

        public delegate ReadOnlySpan<TCollection> SpanCollectionSelectorDelegate(TIn input);
        public delegate ReadOnlySpan<TCollection> SpanCollectionWithIndexSelectorDelegate(TIn input, int index);
        public delegate SpanEnumerator<TSpan2, TCollection, TOperator2> CollectionSelectorDelegate(TIn input);
        public delegate SpanEnumerator<TSpan2, TCollection, TOperator2> CollectionWithIndexSelectorDelegate(TIn input, int index);

        internal readonly CollectionWithIndexSelectorDelegate CollectionSelector;
        internal readonly Func<TIn, TCollection, TOut> ResultSelector;

        internal TIn? CurrentSource;
        internal TCollection[]? CurrentCollectionArray;
        internal int CurrentCollectionLength;
        internal int CurrentCollectionIndex;
        internal int Index;


        internal SelectManyOperator(TOperator op, CollectionWithIndexSelectorDelegate collectionSelector, Func<TIn, TCollection, TOut> resultSelector)
        {
            Operator = op;
            CollectionSelector = collectionSelector;
            ResultSelector = resultSelector;

            CurrentSource = default;
            CurrentCollectionArray = null;
            CurrentCollectionLength = -1;
            CurrentCollectionIndex = -1;
            Index = -1;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TOut TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (CurrentCollectionArray != null)
            {
                if (++CurrentCollectionIndex < CurrentCollectionLength)
                {
                    success = true;
                    return ResultSelector(CurrentSource!, CurrentCollectionArray[CurrentCollectionIndex]);
                }
                else
                {
                    ArrayPool<TCollection>.Shared.Return(CurrentCollectionArray);
                    CurrentCollectionArray = null;
                }
            }

            while (true)
            {
                var current = Operator.TryMoveNext(ref source, out bool ok);
                if (!ok)
                {
                    success = false;
                    return default!;
                }

                CurrentSource = current;
                var collection = CollectionSelector(current, ++Index);
                var collectionSpan = collection.ToArrayPool(out CurrentCollectionArray);
                CurrentCollectionLength = collectionSpan.Length;
                CurrentCollectionIndex = 0;

                if (CurrentCollectionIndex < CurrentCollectionLength)
                {
                    success = true;
                    return ResultSelector(CurrentSource, CurrentCollectionArray[CurrentCollectionIndex]);
                }
            }
        }

        public void Dispose()
        {
            if (CurrentCollectionArray != null)
            {
                ArrayPool<TCollection>.Shared.Return(CurrentCollectionArray);
                CurrentCollectionArray = null;
            }
        }
    }
}
