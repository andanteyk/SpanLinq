using System.Buffers;
using System.Collections;

namespace SpanLinq
{
    public class ArrayPoolList<T> : IList<T>, IDisposable
    {
        private T[] m_Array;
        private int m_Length;


        public ArrayPoolList()
        {
            m_Array = ArrayPool<T>.Shared.Rent(16);
            m_Length = 0;
        }

        public ArrayPoolList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            m_Array = ArrayPool<T>.Shared.Rent(capacity);
            m_Length = 0;
        }

        public ArrayPoolList(ReadOnlySpan<T> span)
        {
            m_Array = ArrayPool<T>.Shared.Rent(span.Length);
            span.CopyTo(m_Array);
            m_Length = span.Length;
        }

        public ArrayPoolList(IEnumerable<T> original)
        {
            if (original is ICollection<T> genericCollection)
            {
                m_Array = ArrayPool<T>.Shared.Rent(genericCollection.Count);
                m_Length = genericCollection.Count;

                genericCollection.CopyTo(m_Array, 0);
            }
            else if (original is ICollection collection)
            {
                m_Array = ArrayPool<T>.Shared.Rent(collection.Count);
                m_Length = collection.Count;

                collection.CopyTo(m_Array, 0);
            }
            else
            {
                m_Array = ArrayPool<T>.Shared.Rent(m_Length = 4);
                int i = 0;
                foreach (var element in original)
                {
                    m_Array[i++] = element;

                    if (i >= m_Array.Length)
                    {
                        Resize(ref m_Array, m_Array.Length << 1);
                    }
                }
                m_Length = i;
            }
        }


        private static void Resize(ref T[] old, int size)
        {
            var newArray = ArrayPool<T>.Shared.Rent(size);
            old.CopyTo(newArray, 0);
            ArrayPool<T>.Shared.Return(old, true);
            old = newArray;
        }


        public T this[int index]
        {
            get
            {
                if ((uint)index < m_Length)
                    return m_Array![index];
                else
                    throw new IndexOutOfRangeException(nameof(index));
            }
            set
            {
                if ((uint)index < m_Length)
                    m_Array![index] = value;
                else
                    throw new IndexOutOfRangeException(nameof(index));
            }
        }

        public int Count => m_Length;

        public bool IsReadOnly => false;


        public void Add(T item)
        {
            if (m_Length < m_Array!.Length)
            {
                m_Array[m_Length++] = item;
            }
            else
            {
                Resize(ref m_Array, m_Length + 1);
                m_Array[m_Length++] = item;
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (items is ICollection<T> genericCollection)
            {
                if (m_Length + genericCollection.Count >= m_Array!.Length)
                {
                    Resize(ref m_Array, m_Length + genericCollection.Count);
                }
                genericCollection.CopyTo(m_Array, m_Length);
                m_Length += genericCollection.Count;
            }
            else if (items is ICollection collection)
            {
                if (m_Length + collection.Count >= m_Array!.Length)
                {
                    Resize(ref m_Array, m_Length + collection.Count);
                }
                collection.CopyTo(m_Array, m_Length);
                m_Length += collection.Count;
            }
            else
            {
                foreach (var item in items)
                {
                    Add(item);
                }
            }
        }

        public void AddRange(ReadOnlySpan<T> items)
        {
            if (m_Length + items.Length >= m_Array!.Length)
            {
                Resize(ref m_Array, m_Length + items.Length);
            }
            items.CopyTo(m_Array.AsSpan(m_Length..));
            m_Length += items.Length;
        }

        public Span<T> AsSpan()
        {
            return m_Array![..m_Length];
        }

        public void Clear()
        {
            // for gc
            Array.Clear(m_Array, 0, m_Length);
            m_Length = 0;
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(m_Array, item, 0, m_Length) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(m_Array, 0, array, arrayIndex, m_Length);
        }

        public void Dispose()
        {
            if (m_Array != null)
            {
                ArrayPool<T>.Shared.Return(m_Array, true);
                m_Array = null!;
            }
        }

        public T? Find(Predicate<T> predicate)
        {
            foreach (var e in AsSpan())
            {
                if (predicate(e))
                    return e;
            }
            return default(T);
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int IndexOf(T item)
        {
            return Array.IndexOf(m_Array, item, 0, m_Length);
        }

        public void Insert(int index, T item)
        {
            if ((uint)index > m_Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (m_Length >= m_Array!.Length)
            {
                Resize(ref m_Array, m_Length + 1);
            }
            Array.Copy(m_Array, index, m_Array, index + 1, m_Length - index);
            m_Array[index] = item;
            m_Length++;
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(m_Array, item, 0, m_Length);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if ((uint)index >= m_Length)
                throw new ArgumentOutOfRangeException();

            if (index == m_Length - 1)
            {
                m_Length--;
                return;
            }

            Array.Copy(m_Array, index + 1, m_Array, index, m_Length - index - 1);
            m_Length--;
        }

        public override string ToString()
        {
            return $"{m_Length} {typeof(T).Name} Items";
        }

        public struct Enumerator : IEnumerator<T>
        {
            private readonly ArrayPoolList<T> m_List;
            private int m_Index;

            internal Enumerator(ArrayPoolList<T> list)
            {
                m_List = list;
                m_Index = -1;
            }

            public T Current => m_List[m_Index];

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                m_Index = int.MinValue;
            }

            public bool MoveNext()
            {
                return (uint)++m_Index < m_List.m_Length;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }
    }

    public static class ArrayPoolListExtensions
    {
        public static ArrayPoolList<T> ToArrayPoolList<T>(this IEnumerable<T> source)
            => new ArrayPoolList<T>(source);
    }
}
