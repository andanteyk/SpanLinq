namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<T, TOut, OfTypeOperator<T, T, TOut, IdentityOperator<T>>> OfType<T, TOut>(this ReadOnlySpan<T> span)
        {
            return new(span, new(new()));
        }

        public static SpanEnumerator<T, TOut, OfTypeOperator<T, T, TOut, IdentityOperator<T>>> OfType<T, TOut>(this Span<T> span)
        {
            return new(span, new(new()));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOutNext, OfTypeOperator<TSource, TOut, TOutNext, TOperator>> OfType<TOutNext>()
        {
            return new(Source, new(Operator));
        }
    }

    public struct OfTypeOperator<TSpan, TIn, TOut, TOperator> : ISpanOperator<TSpan, TOut>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;

        internal OfTypeOperator(TOperator op)
        {
            Operator = op;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            length = default;
            return false;
        }

        public TOut TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            while (true)
            {
                var current = Operator.TryMoveNext(ref source, out bool ok);
                if (!ok)
                {
                    success = false;
                    return default!;
                }

                if (current == null)
                {
                    continue;
                }

                ok = OfTypeHelper<TIn, TOut>.Instance.OfType(current, out var currentOut);
                if (ok)
                {
                    success = true;
                    return currentOut;
                }
            }
        }
    }


    internal class OfTypeHelper<TFrom, TTo>
    {
        public static OfTypeHelper<TFrom, TTo> Instance { get; } = CreateInstance();

        internal static OfTypeHelper<TFrom, TTo> CreateInstance()
        {
            bool isFromNullable = typeof(TFrom).IsGenericType && typeof(TFrom).GetGenericTypeDefinition() == typeof(Nullable<>);
            bool isToNullable = typeof(TTo).IsGenericType && typeof(TTo).GetGenericTypeDefinition() == typeof(Nullable<>);

            if (isFromNullable && isToNullable && typeof(TFrom).GetGenericArguments()[0] == typeof(TTo).GetGenericArguments()[0])
            {
                return (OfTypeHelper<TFrom, TTo>)Activator.CreateInstance(typeof(NullableOfTypeHelper<>).MakeGenericType(typeof(TFrom).GetGenericArguments()[0]))!;
            }
            if (isToNullable && typeof(TTo).GetGenericArguments()[0] == typeof(TFrom))
            {
                return (OfTypeHelper<TFrom, TTo>)Activator.CreateInstance(typeof(ToNullableOfTypeHelper<>).MakeGenericType(typeof(TFrom)))!;
            }
            if (typeof(TFrom) == typeof(TTo) && typeof(TFrom).IsValueType && !(isFromNullable || isToNullable))
            {
                return (OfTypeHelper<TFrom, TTo>)Activator.CreateInstance(typeof(StructOfTypeHelper<>).MakeGenericType(typeof(TFrom)))!;
            }
            if (!typeof(TTo).IsValueType)
            {
                return (OfTypeHelper<TFrom, TTo>)Activator.CreateInstance(typeof(ClassOfTypeHelper<,>).MakeGenericType(typeof(TFrom), typeof(TTo)))!;
            }

            return new OfTypeHelper<TFrom, TTo>();
        }

        public virtual bool OfType(TFrom obj, out TTo result)
        {
            if (obj is TTo castable)
            {
                result = castable;
                return true;
            }
            result = default!;
            return false;
        }
    }

    internal class ClassOfTypeHelper<TFrom, TTo> : OfTypeHelper<TFrom, TTo>
        where TTo : class
    {
        public override bool OfType(TFrom obj, out TTo result)
        {
            if (obj is TTo castable)
            {
                result = castable;
                return true;
            }
            result = default!;
            return false;
        }
    }

    internal class StructOfTypeHelper<T> : OfTypeHelper<T, T>
        where T : struct
    {
        public override bool OfType(T obj, out T result)
        {
            result = obj;
            return true;
        }
    }

    internal class ToNullableOfTypeHelper<T> : OfTypeHelper<T, T?>
        where T : struct
    {
        public override bool OfType(T obj, out T? result)
        {
            result = obj;
            return true;
        }
    }

    internal class NullableOfTypeHelper<T> : OfTypeHelper<T?, T?>
        where T : struct
    {
        public override bool OfType(T? obj, out T? result)
        {
            result = obj;
            return obj != null;
        }
    }
}
