using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TIn, GroupList<TKey, TIn>, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TIn, GroupList<TKey, TIn>, EqualityComparer<TKey>>> GroupBy<TIn, TKey>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector)
        {
            return new(span, new(new(), keySelector, x => x, (key, elements) => new GroupList<TKey, TIn>(key, elements.ToArray()), EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, GroupList<TKey, TIn>, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TIn, GroupList<TKey, TIn>, TComparer>> GroupBy<TIn, TKey, TComparer>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, x => x, (key, elements) => new GroupList<TKey, TIn>(key, elements.ToArray()), comparer));
        }

        public static SpanEnumerator<TIn, TOut, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TIn, TOut, EqualityComparer<TKey>>> GroupBy<TIn, TOut, TKey>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, Func<TKey, IList<TIn>, TOut> resultSelector)
        {
            return new(span, new(new(), keySelector, x => x, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, TOut, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TIn, TOut, TComparer>> GroupBy<TIn, TOut, TKey, TComparer>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, Func<TKey, IList<TIn>, TOut> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, x => x, resultSelector, comparer));
        }

        public static SpanEnumerator<TIn, GroupList<TKey, TElement>, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TElement, GroupList<TKey, TElement>, EqualityComparer<TKey>>> GroupBy<TIn, TKey, TElement>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TElement> elementSelector)
        {
            return new(span, new(new(), keySelector, elementSelector, (key, elements) => new GroupList<TKey, TElement>(key, elements.ToArray()), EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, GroupList<TKey, TElement>, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TElement, GroupList<TKey, TElement>, TComparer>> GroupBy<TIn, TKey, TElement, TComparer>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TElement> elementSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, elementSelector, (key, elements) => new GroupList<TKey, TElement>(key, elements.ToArray()), comparer));
        }

        public static SpanEnumerator<TIn, TOut, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TElement, TOut, EqualityComparer<TKey>>> GroupBy<TIn, TOut, TKey, TElement>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TElement> elementSelector, Func<TKey, IList<TElement>, TOut> resultSelector)
        {
            return new(span, new(new(), keySelector, elementSelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, TOut, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TElement, TOut, TComparer>> GroupBy<TIn, TOut, TKey, TElement, TComparer>(this ReadOnlySpan<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TElement> elementSelector, Func<TKey, IList<TElement>, TOut> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, elementSelector, resultSelector, comparer));
        }




        public static SpanEnumerator<TIn, GroupList<TKey, TIn>, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TIn, GroupList<TKey, TIn>, EqualityComparer<TKey>>> GroupBy<TIn, TKey>(this Span<TIn> span, Func<TIn, TKey> keySelector)
        {
            return new(span, new(new(), keySelector, x => x, (key, elements) => new GroupList<TKey, TIn>(key, elements.ToArray()), EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, GroupList<TKey, TIn>, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TIn, GroupList<TKey, TIn>, TComparer>> GroupBy<TIn, TKey, TComparer>(this Span<TIn> span, Func<TIn, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, x => x, (key, elements) => new GroupList<TKey, TIn>(key, elements.ToArray()), comparer));
        }

        public static SpanEnumerator<TIn, TOut, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TIn, TOut, EqualityComparer<TKey>>> GroupBy<TIn, TOut, TKey>(this Span<TIn> span, Func<TIn, TKey> keySelector, Func<TKey, IList<TIn>, TOut> resultSelector)
        {
            return new(span, new(new(), keySelector, x => x, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, TOut, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TIn, TOut, TComparer>> GroupBy<TIn, TOut, TKey, TComparer>(this Span<TIn> span, Func<TIn, TKey> keySelector, Func<TKey, IList<TIn>, TOut> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, x => x, resultSelector, comparer));
        }

        public static SpanEnumerator<TIn, GroupList<TKey, TElement>, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TElement, GroupList<TKey, TElement>, EqualityComparer<TKey>>> GroupBy<TIn, TKey, TElement>(this Span<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TElement> elementSelector)
        {
            return new(span, new(new(), keySelector, elementSelector, (key, elements) => new GroupList<TKey, TElement>(key, elements.ToArray()), EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, GroupList<TKey, TElement>, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TElement, GroupList<TKey, TElement>, TComparer>> GroupBy<TIn, TKey, TElement, TComparer>(this Span<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TElement> elementSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, elementSelector, (key, elements) => new GroupList<TKey, TElement>(key, elements.ToArray()), comparer));
        }

        public static SpanEnumerator<TIn, TOut, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TElement, TOut, EqualityComparer<TKey>>> GroupBy<TIn, TOut, TKey, TElement>(this Span<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TElement> elementSelector, Func<TKey, IList<TElement>, TOut> resultSelector)
        {
            return new(span, new(new(), keySelector, elementSelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public static SpanEnumerator<TIn, TOut, GroupByOperator<TIn, TIn, IdentityOperator<TIn>, TKey, TElement, TOut, TComparer>> GroupBy<TIn, TOut, TKey, TElement, TComparer>(this Span<TIn> span, Func<TIn, TKey> keySelector, Func<TIn, TElement> elementSelector, Func<TKey, IList<TElement>, TOut> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(span, new(new(), keySelector, elementSelector, resultSelector, comparer));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, GroupList<TKey, TOut>, GroupByOperator<TSource, TOut, TOperator, TKey, TOut, GroupList<TKey, TOut>, EqualityComparer<TKey>>> GroupBy<TKey>(Func<TOut, TKey> keySelector)
        {
            return new(Source, new(Operator, keySelector, x => x, (key, elements) => new GroupList<TKey, TOut>(key, elements.ToArray()), EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, GroupList<TKey, TOut>, GroupByOperator<TSource, TOut, TOperator, TKey, TOut, GroupList<TKey, TOut>, TComparer>> GroupBy<TKey, TComparer>(Func<TOut, TKey> keySelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, x => x, (key, elements) => new GroupList<TKey, TOut>(key, elements.ToArray()), comparer));
        }

        public SpanEnumerator<TSource, TOutNext, GroupByOperator<TSource, TOut, TOperator, TKey, TOut, TOutNext, EqualityComparer<TKey>>> GroupBy<TKey, TOutNext>(Func<TOut, TKey> keySelector, Func<TKey, IList<TOut>, TOutNext> resultSelector)
        {
            return new(Source, new(Operator, keySelector, x => x, resultSelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, TOutNext, GroupByOperator<TSource, TOut, TOperator, TKey, TOut, TOutNext, TComparer>> GroupBy<TKey, TOutNext, TComparer>(Func<TOut, TKey> keySelector, Func<TKey, IList<TOut>, TOutNext> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, x => x, resultSelector, comparer));
        }

        public SpanEnumerator<TSource, GroupList<TKey, TElement>, GroupByOperator<TSource, TOut, TOperator, TKey, TElement, GroupList<TKey, TElement>, EqualityComparer<TKey>>> GroupBy<TKey, TElement>(Func<TOut, TKey> keySelector, Func<TOut, TElement> elementSelector)
        {
            return new(Source, new(Operator, keySelector, elementSelector, (key, elements) => new GroupList<TKey, TElement>(key, elements.ToArray()), EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, GroupList<TKey, TElement>, GroupByOperator<TSource, TOut, TOperator, TKey, TElement, GroupList<TKey, TElement>, TComparer>> GroupBy<TKey, TElement, TComparer>(Func<TOut, TKey> keySelector, Func<TOut, TElement> elementSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, elementSelector, (key, elements) => new GroupList<TKey, TElement>(key, elements.ToArray()), comparer));
        }

        public SpanEnumerator<TSource, TOutNext, GroupByOperator<TSource, TOut, TOperator, TKey, TElement, TOutNext, EqualityComparer<TKey>>> GroupBy<TKey, TElement, TOutNext>(Func<TOut, TKey> keySelector, Func<TOut, TElement> elementSelector, Func<TKey, IList<TElement>, TOutNext> resultSelector)
        {
            return new(Source, new(Operator, keySelector, elementSelector, resultSelector, EqualityComparer<TKey>.Default));
        }

        public SpanEnumerator<TSource, TOutNext, GroupByOperator<TSource, TOut, TOperator, TKey, TElement, TOutNext, TComparer>> GroupBy<TKey, TElement, TOutNext, TComparer>(Func<TOut, TKey> keySelector, Func<TOut, TElement> elementSelector, Func<TKey, IList<TElement>, TOutNext> resultSelector, TComparer comparer)
            where TComparer : IEqualityComparer<TKey>
        {
            return new(Source, new(Operator, keySelector, elementSelector, resultSelector, comparer));
        }
    }

    public struct GroupByOperator<TSpan, TIn, TOperator, TKey, TElement, TOut, TComparer> : ISpanOperator<TSpan, TOut>, IDisposable
        where TOperator : ISpanOperator<TSpan, TIn>
        where TComparer : IEqualityComparer<TKey>
    {
        internal TOperator Operator;
        internal readonly Func<TIn, TKey> KeySelector;
        internal readonly Func<TIn, TElement> ElementSelector;
        internal readonly Func<TKey, IList<TElement>, TOut> ResultSelector;
        internal ArrayPoolList<TElement>? NullKeys;
        internal ArrayPoolDictionary<TKey, ArrayPoolList<TElement>> Dictionary;
        internal ArrayPoolDictionary<TKey, ArrayPoolList<TElement>>.Enumerator DictionaryEnumerator;
        internal readonly TComparer Comparer;

        internal GroupByOperator(TOperator op, Func<TIn, TKey> keySelector, Func<TIn, TElement> elementSelector, Func<TKey, IList<TElement>, TOut> resultSelector, TComparer comparer)
        {
            Operator = op;
            KeySelector = keySelector;
            ElementSelector = elementSelector;
            ResultSelector = resultSelector;
            NullKeys = null!;
            Dictionary = null!;
            DictionaryEnumerator = default;
            Comparer = comparer;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TOut TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            if (Dictionary == null)
            {
                DoGrouping(ref source);
            }

            if (NullKeys != null)
            {
                success = true;
                var result = ResultSelector(default!, NullKeys);
                NullKeys.Dispose();
                NullKeys = null;
                return result;
            }

            if (DictionaryEnumerator.MoveNext())
            {
                success = true;
                return ResultSelector(DictionaryEnumerator.Current.Key, DictionaryEnumerator.Current.Value);
            }
            else
            {
                success = false;
                return default!;
            }
        }

        private void DoGrouping(ref ReadOnlySpan<TSpan> source)
        {
            Dictionary = new(Comparer);

            while (true)
            {
                var current = Operator.TryMoveNext(ref source, out bool ok);
                if (!ok)
                {
                    break;
                }

                var key = KeySelector(current);
                var element = ElementSelector(current);

                if (key == null)
                {
                    NullKeys ??= new(0);
                    NullKeys.Add(element);
                }
                else if (Dictionary.TryGetValue(key, out var values))
                {
                    values.Add(element);
                }
                else
                {
                    Dictionary.Add(key, new ArrayPoolList<TElement>(0) { element });
                }
            }

            DictionaryEnumerator = Dictionary.GetEnumerator();
        }

        public void Dispose()
        {
            if (Dictionary != null)
            {
                foreach (var pair in Dictionary)
                {
                    pair.Value.Dispose();
                }
                Dictionary.Dispose();
                Dictionary = null!;
            }
            if (NullKeys != null)
            {
                NullKeys.Dispose();
                NullKeys = null;
            }
        }
    }


    // TODO: opt.
    public class GroupList<TKey, TElement> : IGrouping<TKey, TElement>, IList<TElement>, ICollection<TElement>, ICollection
    {
        public TKey Key { get; init; }
        private TElement[] Elements { get; init; }

        public GroupList(TKey key, TElement[] elements)
        {
            Key = key;
            Elements = elements;
        }


        public TElement this[int index] { get => Elements[index]; set => throw new NotSupportedException(); }

        public int Count => Elements.Length;

        public bool IsReadOnly => true;

        public bool IsSynchronized => Elements.IsSynchronized;

        public object SyncRoot => Elements.SyncRoot;

        public void Add(TElement item) => throw new NotSupportedException();

        public void Clear() => throw new NotSupportedException();

        public bool Contains(TElement item)
        {
            return Array.IndexOf(Elements, item) >= 0;
        }

        public void CopyTo(TElement[] array, int arrayIndex)
        {
            Elements.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return Elements.AsEnumerable().GetEnumerator();
        }

        public int IndexOf(TElement item)
        {
            return Array.IndexOf(Elements, item);
        }

        public void Insert(int index, TElement item) => throw new NotSupportedException();

        public bool Remove(TElement item) => throw new NotSupportedException();

        public void RemoveAt(int index) => throw new NotSupportedException();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            Elements.CopyTo(array, index);
        }
    }
}
