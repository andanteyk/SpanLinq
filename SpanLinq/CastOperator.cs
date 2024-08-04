using System.Runtime.CompilerServices;

namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static SpanEnumerator<TIn, TOut, CastOperator<TIn, TIn, TOut, IdentityOperator<TIn>>> Cast<TIn, TOut>(this ReadOnlySpan<TIn> span)
        {
            return new(span, new(new()));
        }

        public static SpanEnumerator<TIn, TOut, CastOperator<TIn, TIn, TOut, IdentityOperator<TIn>>> Cast<TIn, TOut>(this Span<TIn> span)
        {
            return new(span, new(new()));
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public SpanEnumerator<TSource, TOutNext, CastOperator<TSource, TOut, TOutNext, TOperator>> Cast<TOutNext>()
        {
            return new(Source, new(Operator));
        }
    }

    public struct CastOperator<TSpan, TIn, TOut, TOperator> : ISpanOperator<TSpan, TOut>
        where TOperator : ISpanOperator<TSpan, TIn>
    {
        internal TOperator Operator;

        internal CastOperator(TOperator op)
        {
            Operator = op;
        }

        public bool TryGetNonEnumeratedCount(ReadOnlySpan<TSpan> source, out int length)
        {
            return Operator.TryGetNonEnumeratedCount(source, out length);
        }

        public TOut TryMoveNext(ref ReadOnlySpan<TSpan> source, out bool success)
        {
            var current = Operator.TryMoveNext(ref source, out bool ok);
            if (!ok)
            {
                success = false;
                return default!;
            }

            success = true;
            return CastHelper<TIn, TOut>.Instance.Cast(current);
        }
    }

    internal class CastHelper<TFrom, TTo>
    {
        public static CastHelper<TFrom, TTo> Instance { get; } =
            typeof(TFrom).IsGenericType && typeof(TFrom).GetGenericTypeDefinition() == typeof(Nullable<>) && typeof(TTo).IsGenericType && typeof(TTo).GetGenericTypeDefinition() == typeof(Nullable<>) && typeof(TFrom).GetGenericArguments()[0] == typeof(TTo).GetGenericArguments()[0] ?
            (CastHelper<TFrom, TTo>)Activator.CreateInstance(typeof(NullableCastHelper<>).MakeGenericType(typeof(TFrom).GetGenericArguments()[0]))! :
            typeof(TFrom).IsGenericType && typeof(TFrom).GetGenericTypeDefinition() == typeof(Nullable<>) && typeof(TFrom).GetGenericArguments()[0] == typeof(TTo) ?
            (CastHelper<TFrom, TTo>)Activator.CreateInstance(typeof(FromNullableCastHelper<>).MakeGenericType(typeof(TTo)))! :
            typeof(TTo).IsGenericType && typeof(TTo).GetGenericTypeDefinition() == typeof(Nullable<>) && typeof(TTo).GetGenericArguments()[0] == typeof(TFrom) ?
            (CastHelper<TFrom, TTo>)Activator.CreateInstance(typeof(ToNullableCastHelper<>).MakeGenericType(typeof(TFrom)))! :
            typeof(TFrom) == typeof(TTo) && typeof(TFrom).IsValueType && !(typeof(TFrom).IsGenericType && typeof(TFrom).GetGenericTypeDefinition() == typeof(Nullable<>)) && typeof(TTo).IsValueType && !(typeof(TTo).IsGenericType && typeof(TTo).GetGenericTypeDefinition() == typeof(Nullable<>)) ?
            (CastHelper<TFrom, TTo>)Activator.CreateInstance(typeof(StructCastHelper<>).MakeGenericType(typeof(TFrom)))! :
            new CastHelper<TFrom, TTo>();

        public virtual TTo Cast(TFrom obj)
        {
            return (TTo)(object)obj!;
        }
    }

    internal class StructCastHelper<T> : CastHelper<T, T>
        where T : struct
    {
        public override T Cast(T obj)
        {
            return obj;
        }
    }

    internal class ToNullableCastHelper<T> : CastHelper<T, T?>
        where T : struct
    {
        public override T? Cast(T obj)
        {
            return (T?)obj;
        }
    }

    internal class FromNullableCastHelper<T> : CastHelper<T?, T>
        where T : struct
    {
        public override T Cast(T? obj)
        {
            return (T)obj!;
        }
    }

    internal class NullableCastHelper<T> : CastHelper<T?, T?>
        where T : struct
    {
        public override T? Cast(T? obj)
        {
            return obj;
        }
    }
}
