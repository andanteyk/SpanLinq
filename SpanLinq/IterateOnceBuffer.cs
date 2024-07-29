using System.Buffers;
using System.Collections;

namespace SpanLinq
{
    public struct IterateOnceBuffer<T> : ICollection<T>, IEnumerable<T>, IEnumerator<T>, IDisposable
    {
        private readonly T[] Array;
        private int Index;
        private int Length;

        internal IterateOnceBuffer(T[] array, int length)
        {
            Array = array;
            Index = -1;
            Length = length;
        }

        public T Current => Array[Index];

        object? IEnumerator.Current => Current;

        public int Count => Length;

        public bool IsReadOnly => true;

        public void Dispose()
        {
            if (Index != int.MinValue)
            {
                Index = int.MinValue;
                ArrayPool<T>.Shared.Return(Array);
            }
        }

        public IterateOnceBuffer<T> GetEnumerator()
        {
            if (Index == -1)
            {
                return this;
            }

            throw new InvalidOperationException("can iterate once");
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        public bool MoveNext()
        {
            if (Index >= -1)
            {
                if (++Index < Length)
                    return true;

                Dispose();
            }
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (Equals(Array[i], item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.AsSpan(..Length).CopyTo(array.AsSpan(arrayIndex..));
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public static implicit operator ReadOnlySpan<T>(IterateOnceBuffer<T> iterator)
        {
            return iterator.Array.AsSpan(..iterator.Length);
        }
    }
}
