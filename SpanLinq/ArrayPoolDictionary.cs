using System.Buffers;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#pragma warning disable IDE0005
using System.Runtime.InteropServices;
#pragma warning restore

namespace SpanLinq
{
    public sealed partial class ArrayPoolDictionary<TKey, TValue> :
        ICollection<KeyValuePair<TKey, TValue>>,
        IDictionary<TKey, TValue>,
        IEnumerable<KeyValuePair<TKey, TValue>>,
        IReadOnlyCollection<KeyValuePair<TKey, TValue>>,
        IReadOnlyDictionary<TKey, TValue>,
        IDictionary,
        IDisposable
    {

        private readonly record struct Metadata(uint Fingerprint, int ValueIndex)
        {
            public override string ToString()
            {
                return $"dist={Fingerprint >> 8} fingerprint={Fingerprint & 0xff:x2} value=#{ValueIndex}";
            }
        }

        private KeyValuePair<TKey, TValue>[] m_Values;
        private Metadata[] m_Metadata;

        private int m_Size;
        private int m_Shifts = 32 - 2;

        private IEqualityComparer<TKey>? m_Comparer;


        private const int DistanceUnit = 0x100;
        private const long MaxLoadFactorNum = 25;
        private const long MaxLoadFactorDen = 32;



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int TrailingZeroCount(ulong x)
        {
#if NETCOREAPP3_0_OR_GREATER
            return System.Numerics.BitOperations.TrailingZeroCount(x);
#else
            int c = 63;
            x &= ~x + 1;
            if ((x & 0x00000000ffffffff) != 0) c -= 32;
            if ((x & 0x0000ffff0000ffff) != 0) c -= 16;
            if ((x & 0x00ff00ff00ff00ff) != 0) c -= 8;
            if ((x & 0x0f0f0f0f0f0f0f0f) != 0) c -= 4;
            if ((x & 0x3333333333333333) != 0) c -= 2;
            if ((x & 0x5555555555555555) != 0) c -= 1;
            return c;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint HashCodeToFingerprint(int hashCode)
        {
            return DistanceUnit | ((uint)hashCode & 0xff);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int HashCodeToMetadataIndex(int hashCode, int shift)
        {
            return (int)(((uint)hashCode) >> shift);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ref T At<T>(T[] array, int i)
        {
#if !DEBUG && NET5_0_OR_GREATER
            return ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), i);
#else
            return ref array[i];
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool AreEqual(TKey key1, TKey key2, IEqualityComparer<TKey>? comparer)
        {
            if (typeof(TKey).IsValueType)
            {
                if (comparer == null)
                {
                    return EqualityComparer<TKey>.Default.Equals(key1, key2);
                }

                return comparer.Equals(key1, key2);
            }
            else
            {
                return comparer!.Equals(key1, key2);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetHashCode(TKey key, IEqualityComparer<TKey>? comparer)
        {
            if (key is { } notnullKey)
            {
                if (typeof(TKey).IsValueType)
                {
                    if (comparer == null)
                    {
                        return notnullKey.GetHashCode();
                    }

                    return comparer.GetHashCode(notnullKey);
                }
                else
                {
                    return comparer!.GetHashCode(notnullKey);
                }
            }
            else
            {
                return 0;
            }
        }


        private int GetEntryIndex(TKey key)
        {
            var metadata = m_Metadata;
            var values = m_Values;
            var comparer = m_Comparer;

            int hashCode = GetHashCode(key, comparer);
            uint fingerprint = HashCodeToFingerprint(hashCode);
            int metadataIndex = HashCodeToMetadataIndex(hashCode, m_Shifts);

            //*
            var current = At(metadata, metadataIndex);


            // unrolled loop #1
            if (fingerprint == current.Fingerprint && AreEqual(At(values, current.ValueIndex).Key, key, comparer))
            {
                return current.ValueIndex;
            }
            fingerprint += DistanceUnit;
            metadataIndex = IncrementMetadataIndex(metadataIndex);
            current = At(metadata, metadataIndex);

            // unrolled loop #2
            if (fingerprint == current.Fingerprint && AreEqual(At(values, current.ValueIndex).Key, key, comparer))
            {
                return current.ValueIndex;
            }
            fingerprint += DistanceUnit;
            metadataIndex = IncrementMetadataIndex(metadataIndex);
            //metadata = At(m_Metadata, metadataIndex);
            //*/

            return GetEntryIndexFallback(key, fingerprint, metadataIndex);
        }

        private int GetEntryIndexFallback(TKey key, uint fingerprint, int metadataIndex)
        {
            var metadata = m_Metadata;
            var values = m_Values;
            var comparer = m_Comparer;

            var current = At(metadata, metadataIndex);

            while (true)
            {
                if (fingerprint == current.Fingerprint)
                {
                    if (AreEqual(At(values, current.ValueIndex).Key, key, comparer))
                    {
                        return current.ValueIndex;
                    }
                }
                else if (fingerprint > current.Fingerprint)
                {
                    return -1;
                }

                fingerprint += DistanceUnit;
                metadataIndex = IncrementMetadataIndex(metadataIndex);
                current = At(metadata, metadataIndex);
            }
        }

        private bool AddEntry(TKey key, TValue value, bool overwrite)
        {
            var metadata = m_Metadata;
            var values = m_Values;
            var comparer = m_Comparer;

            int hashCode = GetHashCode(key, comparer);
            uint fingerprint = HashCodeToFingerprint(hashCode);
            int metadataIndex = HashCodeToMetadataIndex(hashCode, m_Shifts);


            var current = At(metadata, metadataIndex);
            while (fingerprint <= current.Fingerprint)
            {
                if (fingerprint == current.Fingerprint &&
                    AreEqual(key, At(values, current.ValueIndex).Key, comparer))
                {
                    if (overwrite)
                    {
                        At(values, current.ValueIndex) = new KeyValuePair<TKey, TValue>(key, value);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                fingerprint += DistanceUnit;
                metadataIndex = IncrementMetadataIndex(metadataIndex);
                current = At(metadata, metadataIndex);
            }

            //Console.WriteLine($"{hashCode:x8} {fingerprint:x8} {m_Size} {m_Shifts}");

            m_Size++;
            At(values, m_Size - 1) = new KeyValuePair<TKey, TValue>(key, value);
            PlaceAndShiftUp(new Metadata(fingerprint, m_Size - 1), metadataIndex);


            if (m_Size * MaxLoadFactorDen >= m_Metadata.Length * MaxLoadFactorNum)
            {
                m_Shifts--;
                int newCapacity = 1 << (32 - m_Shifts);
                Resize(newCapacity);
            }

            return true;
        }

        private void Resize(int newCapacity)
        {
            var oldValues = m_Values;
            var oldMetadata = m_Metadata;

            m_Values = ArrayPool<KeyValuePair<TKey, TValue>>.Shared.Rent(newCapacity);
            oldValues.AsSpan(..m_Size).CopyTo(m_Values.AsSpan());
            m_Metadata = ArrayPool<Metadata>.Shared.Rent(newCapacity);
            m_Metadata.AsSpan().Clear();

            for (int i = 0; i < m_Size; i++)
            {
                (uint fingerprint, int metadataIndex) = NextWhileLess(At(m_Values, i).Key);
                PlaceAndShiftUp(new Metadata(fingerprint, i), metadataIndex);
            }

            ArrayPool<KeyValuePair<TKey, TValue>>.Shared.Return(oldValues, true);
            ArrayPool<Metadata>.Shared.Return(oldMetadata);
        }

        private (uint fingerprint, int metadataIndex) NextWhileLess(TKey key)
        {
            int hashCode = GetHashCode(key, m_Comparer);
            uint fingerprint = HashCodeToFingerprint(hashCode);
            int metadataIndex = HashCodeToMetadataIndex(hashCode, m_Shifts);

            while (fingerprint < At(m_Metadata, metadataIndex).Fingerprint)
            {
                fingerprint += DistanceUnit;
                metadataIndex = IncrementMetadataIndex(metadataIndex);
            }

            return (fingerprint, metadataIndex);
        }

        private void PlaceAndShiftUp(Metadata current, int metadataIndex)
        {
            var metadata = m_Metadata;

            while (At(metadata, metadataIndex).Fingerprint != 0)
            {
                (current, At(metadata, metadataIndex)) = (At(metadata, metadataIndex), current);
                current = new Metadata(current.Fingerprint + DistanceUnit, current.ValueIndex);
                metadataIndex = IncrementMetadataIndex(metadataIndex);
            }
            At(metadata, metadataIndex) = current;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int IncrementMetadataIndex(int metadataIndex)
        {
            return (metadataIndex + 1) & (m_Metadata.Length - 1);
        }

        private bool RemoveEntry(TKey key)
        {
            var metadata = m_Metadata;
            var comparer = m_Comparer;


            (uint fingerprint, int metadataIndex) = NextWhileLess(key);

            while (fingerprint == At(metadata, metadataIndex).Fingerprint &&
                !AreEqual(At(m_Values, At(metadata, metadataIndex).ValueIndex).Key, key, comparer))
            {
                fingerprint += DistanceUnit;
                metadataIndex = IncrementMetadataIndex(metadataIndex);
            }

            if (fingerprint != At(metadata, metadataIndex).Fingerprint)
            {
                return false;
            }

            RemoveAt(metadataIndex);
            return true;
        }

        private void RemoveAt(int metadataIndex)
        {
            var metadata = m_Metadata;
            var values = m_Values;


            int valueIndex = At(metadata, metadataIndex).ValueIndex;

            int nextMetadataIndex = IncrementMetadataIndex(metadataIndex);
            while (At(metadata, nextMetadataIndex).Fingerprint >= DistanceUnit * 2)
            {
                At(metadata, metadataIndex) = new Metadata(At(metadata, nextMetadataIndex).Fingerprint - DistanceUnit, At(metadata, nextMetadataIndex).ValueIndex);
                (metadataIndex, nextMetadataIndex) = (nextMetadataIndex, IncrementMetadataIndex(nextMetadataIndex));
            }

            At(metadata, metadataIndex) = new Metadata();


            if (valueIndex != m_Size - 1)
            {
                At(values, valueIndex) = At(values, m_Size - 1);

                int movingHashCode = GetHashCode(At(values, valueIndex).Key, m_Comparer);
                int movingMetadataIndex = HashCodeToMetadataIndex(movingHashCode, m_Shifts);

                int valueIndexBack = m_Size - 1;
                while (valueIndexBack != At(metadata, movingMetadataIndex).ValueIndex)
                {
                    movingMetadataIndex = IncrementMetadataIndex(movingMetadataIndex);
                }
                At(m_Metadata, movingMetadataIndex) = new Metadata(At(metadata, movingMetadataIndex).Fingerprint, valueIndex);
            }

            m_Size--;
        }

        private void ClearTable()
        {
            m_Metadata.AsSpan().Clear();
            m_Size = 0;
        }

        public bool TryAdd(TKey key, TValue value)
        {
            return AddEntry(key, value, false);
        }

        public void ClearAndSetComparer(IEqualityComparer<TKey> comparer)
        {
            ClearTable();
            m_Comparer = comparer;
        }






        public ArrayPoolDictionary() : this(typeof(TKey).IsValueType ? null : EqualityComparer<TKey>.Default) { }
        public ArrayPoolDictionary(int capacity) : this(capacity, typeof(TKey).IsValueType ? null : EqualityComparer<TKey>.Default) { }
        public ArrayPoolDictionary(IDictionary<TKey, TValue> dictionary) : this(dictionary, typeof(TKey).IsValueType ? null : EqualityComparer<TKey>.Default) { }
        public ArrayPoolDictionary(IEnumerable<KeyValuePair<TKey, TValue>> source) : this(source.Count(), typeof(TKey).IsValueType ? null : EqualityComparer<TKey>.Default) { }

        public ArrayPoolDictionary(IEqualityComparer<TKey>? comparer) : this(4, comparer) { }
        public ArrayPoolDictionary(int capacity, IEqualityComparer<TKey>? comparer)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            capacity = Math.Max(capacity, 4);

            m_Values = ArrayPool<KeyValuePair<TKey, TValue>>.Shared.Rent(capacity);
            m_Metadata = ArrayPool<Metadata>.Shared.Rent(capacity);
            m_Metadata.AsSpan().Clear();

            m_Size = 0;
            m_Shifts = 32 - TrailingZeroCount((ulong)capacity);

            m_Comparer = comparer;
        }

        public ArrayPoolDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey>? comparer)
        {
            if (dictionary is ArrayPoolDictionary<TKey, TValue> cloneSource &&
                cloneSource.m_Comparer == comparer)
            {
                m_Values = ArrayPool<KeyValuePair<TKey, TValue>>.Shared.Rent(cloneSource.m_Values.Length);
                m_Metadata = ArrayPool<Metadata>.Shared.Rent(cloneSource.m_Metadata.Length);
                cloneSource.m_Values.AsSpan().CopyTo(m_Values);
                cloneSource.m_Metadata.AsSpan().CopyTo(m_Metadata);

                m_Size = cloneSource.m_Size;
                m_Shifts = cloneSource.m_Shifts;

                m_Comparer = comparer;
                return;
            }


            int capacity = Math.Max(dictionary.Count(), 4);
            m_Values = ArrayPool<KeyValuePair<TKey, TValue>>.Shared.Rent(capacity);
            m_Metadata = ArrayPool<Metadata>.Shared.Rent(capacity);
            m_Metadata.AsSpan().Clear();

            m_Size = 0;
            m_Shifts = 32 - TrailingZeroCount((ulong)capacity);

            m_Comparer = comparer;

            foreach (var pair in dictionary)
            {
                AddEntry(pair.Key, pair.Value, false);
            }
        }
        public ArrayPoolDictionary(IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer) : this(source.Count(), comparer)
        {
            foreach (var pair in source)
            {
                AddEntry(pair.Key, pair.Value, false);
            }
        }














        public TValue this[TKey key]
        {
            get => GetEntryIndex(key) is int index && index >= 0 ? At(m_Values, index).Value : throw new KeyNotFoundException();
            set => AddEntry(key, value, true);
        }

        public int Count => m_Size;

        public bool IsReadOnly => false;

        public readonly struct KeyCollection : ICollection<TKey>, ICollection, IReadOnlyCollection<TKey>
        {
            private readonly ArrayPoolDictionary<TKey, TValue> m_Parent;

            internal KeyCollection(ArrayPoolDictionary<TKey, TValue> parent)
            {
                m_Parent = parent;
            }

            public int Count => m_Parent.Count;

            public bool IsReadOnly => true;

            public bool IsSynchronized => false;

            public object SyncRoot => ((ICollection)m_Parent).SyncRoot;

            public void Add(TKey item) => throw new NotSupportedException();

            public void Clear() => throw new NotSupportedException();

            public bool Contains(TKey item)
            {
                return m_Parent.ContainsKey(item);
            }

            public void CopyTo(TKey[] array, int arrayIndex)
            {
                if (array.Length - arrayIndex < m_Parent.m_Size)
                    throw new ArgumentException(nameof(array));

                for (int i = 0; i < m_Parent.m_Size; i++)
                {
                    array[arrayIndex + i] = m_Parent.m_Values[i].Key;
                }
            }

            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => GetEnumerator();

            public bool Remove(TKey item) => throw new NotSupportedException();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public Enumerator GetEnumerator()
            {
                return new Enumerator(m_Parent);
            }

            public void CopyTo(Array array, int index)
            {
                if (array is not TKey[] tkey)
                    throw new InvalidCastException(nameof(array));
                if (array.Length - index < m_Parent.m_Size)
                    throw new ArgumentException(nameof(array));

                for (int i = 0; i < m_Parent.m_Size; i++)
                {
                    tkey[i + index] = m_Parent.m_Values[i].Key;
                }
            }

            public struct Enumerator : IEnumerator<TKey>
            {
                private readonly ArrayPoolDictionary<TKey, TValue> m_Parent;
                private int m_Index;

                internal Enumerator(ArrayPoolDictionary<TKey, TValue> parent)
                {
                    m_Parent = parent;
                    m_Index = -1;
                }

                public TKey Current => m_Parent.m_Values[m_Index].Key;

                object? IEnumerator.Current => Current;

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    return ++m_Index < m_Parent.m_Size;
                }

                public void Reset() => throw new NotSupportedException();
            }
        }

        public readonly struct ValueCollection : ICollection<TValue>, ICollection, IReadOnlyCollection<TValue>
        {
            private readonly ArrayPoolDictionary<TKey, TValue> m_Parent;

            internal ValueCollection(ArrayPoolDictionary<TKey, TValue> parent)
            {
                m_Parent = parent;
            }

            public int Count => m_Parent.Count;

            public bool IsReadOnly => true;

            public bool IsSynchronized => false;

            public object SyncRoot => ((ICollection)m_Parent).SyncRoot;

            public void Add(TValue item) => throw new NotSupportedException();

            public void Clear() => throw new NotSupportedException();

            public bool Contains(TValue item)
            {
                return m_Parent.ContainsValue(item);
            }

            public void CopyTo(TValue[] array, int arrayIndex)
            {
                if (array.Length - arrayIndex < m_Parent.m_Size)
                    throw new ArgumentException(nameof(array));

                for (int i = 0; i < m_Parent.m_Size; i++)
                {
                    array[arrayIndex + i] = m_Parent.m_Values[i].Value;
                }
            }

            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => GetEnumerator();

            public bool Remove(TValue item) => throw new NotSupportedException();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public Enumerator GetEnumerator()
            {
                return new Enumerator(m_Parent);
            }

            public void CopyTo(Array array, int index)
            {
                if (array is not TValue[] tvalue)
                    throw new InvalidCastException(nameof(array));
                if (array.Length - index < m_Parent.m_Size)
                    throw new ArgumentException(nameof(array));

                for (int i = 0; i < m_Parent.m_Size; i++)
                {
                    tvalue[i + index] = m_Parent.m_Values[i].Value;
                }
            }

            public struct Enumerator : IEnumerator<TValue>
            {
                private readonly ArrayPoolDictionary<TKey, TValue> m_Parent;
                private int m_Index;

                internal Enumerator(ArrayPoolDictionary<TKey, TValue> parent)
                {
                    m_Parent = parent;
                    m_Index = -1;
                }

                public TValue Current => m_Parent.m_Values[m_Index].Value;

                object? IEnumerator.Current => Current;

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    return ++m_Index < m_Parent.m_Size;
                }

                public void Reset() => throw new NotSupportedException();
            }
        }

        public KeyCollection Keys => new KeyCollection(this);

        ICollection<TKey> IDictionary<TKey, TValue>.Keys => Keys;

        public ValueCollection Values => new ValueCollection(this);

        ICollection<TValue> IDictionary<TKey, TValue>.Values => Values;

        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

        public bool IsFixedSize => false;

        ICollection IDictionary.Keys => Keys;

        ICollection IDictionary.Values => Values;

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        object? IDictionary.this[object key]
        {
            get => key is TKey tkey ? this[tkey] : throw new InvalidCastException(nameof(key));
            set
            {
                if (key is TKey tkey && value is TValue tvalue)
                    this[tkey] = tvalue;
                else
                    throw new InvalidCastException();
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (!AddEntry(item.Key, item.Value, false))
                throw new InvalidOperationException("key duplicated");
        }

        public void Add(TKey key, TValue value)
        {
            if (!AddEntry(key, value, false))
                throw new InvalidOperationException("key duplicated");
        }

        public void Clear()
        {
            ClearTable();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return GetEntryIndex(item.Key) is int index && index >= 0 &&
                EqualityComparer<TValue>.Default.Equals(item.Value, m_Values[index].Value);
        }

        public bool ContainsKey(TKey key)
        {
            return GetEntryIndex(key) >= 0;
        }

        public bool ContainsValue(TValue value)
        {
            foreach (var pair in m_Values.AsSpan(..m_Size))
            {
                if (EqualityComparer<TValue>.Default.Equals(pair.Value, value))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex < m_Size)
                throw new ArgumentException(nameof(array));

            m_Values.AsSpan(..m_Size).CopyTo(array.AsSpan(arrayIndex..));
        }

        public void Dispose()
        {
            if (m_Values != null)
            {
                ArrayPool<KeyValuePair<TKey, TValue>>.Shared.Return(m_Values, true);
                m_Values = null!;
            }
            if (m_Metadata != null)
            {
                ArrayPool<Metadata>.Shared.Return(m_Metadata);
                m_Metadata = null!;
            }
            m_Size = 0;
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
            => GetEnumerator();

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (GetEntryIndex(item.Key) is int index && index >= 0 &&
                EqualityComparer<TValue>.Default.Equals(item.Value, m_Values[index].Value))
            {
                return RemoveEntry(item.Key);
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            return RemoveEntry(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (GetEntryIndex(key) is int index && index >= 0)
            {
                value = m_Values[index].Value;
                return true;
            }
            else
            {
                value = default!;
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();


        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        void IDictionary.Add(object key, object? value)
        {
            if (key is not TKey tkey)
                throw new InvalidCastException(nameof(key));
            if (value is not TValue tvalue)
                throw new InvalidCastException(nameof(value));

            Add(tkey, tvalue);
        }

        bool IDictionary.Contains(object key)
        {
            if (key is not TKey tkey)
                throw new InvalidCastException(nameof(key));

            return ContainsKey(tkey);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator() => GetEnumerator();

        void IDictionary.Remove(object key)
        {
            if (key is not TKey tkey)
                throw new InvalidCastException(nameof(key));

            Remove(tkey);
        }

        void ICollection.CopyTo(Array array, int index)
        {
            if (array is not KeyValuePair<TKey, TValue>[] tarray)
                throw new InvalidCastException(nameof(array));

            CopyTo(tarray, index);
        }

        public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator
        {
            private readonly ArrayPoolDictionary<TKey, TValue> m_Parent;
            private int m_Index;

            internal Enumerator(ArrayPoolDictionary<TKey, TValue> parent)
            {
                m_Parent = parent;
                m_Index = -1;
            }

            public KeyValuePair<TKey, TValue> Current => m_Parent.m_Values[m_Index];

            public DictionaryEntry Entry => new DictionaryEntry(Current.Key!, Current.Value);

            public object Key => Current.Key!;

            public object? Value => Current.Value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++m_Index < m_Parent.m_Size;
            }

            public void Reset() => throw new NotSupportedException();
        }

        public override string ToString()
        {
            return $"{m_Size} items";
        }
    }
}

namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}
