using System.Buffers;

namespace SpanLinq
{
    public class ObjectPool<T> where T : class
    {
        [ThreadStatic]
        private static ObjectPool<T>? shared = null;
        public static ObjectPool<T> Shared => shared ??= new ObjectPool<T>();

        private enum UsedFlags : byte
        {
            Unused,
            Used,
        }

        private T[] Pool;
        private UsedFlags[] Used;
        private int StartIndex;

        private ObjectPool()
        {
            Pool = ArrayPool<T>.Shared.Rent(16);
            Used = ArrayPool<UsedFlags>.Shared.Rent(16);
            Used.AsSpan().Fill(UsedFlags.Unused);
            StartIndex = -1;
        }

        public T Rent()
        {
            StartIndex++;
            for (int offset = 0; offset < Pool.Length; offset++)
            {
                int i = (StartIndex + offset) & (Pool.Length - 1);

                if (Used[i] == UsedFlags.Unused)
                {
                    Used[i] = UsedFlags.Used;
                    return Pool[i];
                }
            }


            var newPool = ArrayPool<T>.Shared.Rent(Pool.Length << 1);
            var newUsed = ArrayPool<UsedFlags>.Shared.Rent(Used.Length << 1);
            var oldPool = Pool;
            var oldUsed = Used;

            oldPool.AsSpan().CopyTo(newPool);
            oldUsed.AsSpan().CopyTo(newUsed);
            Pool = newPool;
            Used = newUsed;
            int index = oldPool.Length;

            ArrayPool<T>.Shared.Return(oldPool);
            ArrayPool<UsedFlags>.Shared.Return(oldUsed);


            Used[index] = UsedFlags.Used;
            return Pool[index];
        }

        public void Return(T value)
        {
            for (int i = 0; i < Pool.Length; i++)
            {
                if (Used[i] == UsedFlags.Used)
                {
                    if (ReferenceEquals(Pool[i], value))
                    {
                        Used[i] = UsedFlags.Unused;
                        return;
                    }
                }
            }

            throw new InvalidOperationException();
        }

    }
}
