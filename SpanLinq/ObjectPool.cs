using System.Buffers;

namespace SpanLinq
{
    public class ObjectPool<T>
        where T : class, new()
    {
        [ThreadStatic]
        private static ObjectPool<T>? shared;
        public static ObjectPool<T> Shared => shared ??= new ObjectPool<T>();


        private T?[] Pool;

        private ObjectPool()
        {
            Pool = ArrayPool<T?>.Shared.Rent(16);
            Pool.AsSpan().Clear();
        }

        public T Rent()
        {
            for (int i = 0; i < Pool.Length; i++)
            {
                if (Pool[i] is not null)
                {
                    var result = Pool[i];
                    Pool[i] = null;
                    return result!;
                }
            }

            return new();
        }

        public void Return(T value)
        {
            for (int i = 0; i < Pool.Length; i++)
            {
                if (Pool[i] is null)
                {
                    Pool[i] = value;
                    return;
                }
            }

            var newPool = ArrayPool<T>.Shared.Rent(Pool.Length << 1);
            newPool.AsSpan().Clear();
            var oldPool = Pool;

            oldPool.AsSpan().CopyTo(newPool);
            Pool = newPool;
            Pool[oldPool.Length] = value;

            ArrayPool<T?>.Shared.Return(oldPool);
        }
    }

    public static class ObjectPool
    {
        public static TRent SharedRent<TRent>()
            where TRent : class, new()
        {
            return ObjectPool<TRent>.Shared.Rent();
        }
        public static void SharedReturn<TReturn>(TReturn value)
            where TReturn : class, new()
        {
            ObjectPool<TReturn>.Shared.Return(value);
        }
    }
}
