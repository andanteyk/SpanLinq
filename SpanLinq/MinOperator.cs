namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static int Min(this ReadOnlySpan<int> span)
        {
            return new SpanEnumerator<int, int, IdentityOperator<int>>(span, new()).Min(i => i);
        }

        public static long Min(this ReadOnlySpan<long> span)
        {
            return new SpanEnumerator<long, long, IdentityOperator<long>>(span, new()).Min(i => i);
        }

        public static float Min(this ReadOnlySpan<float> span)
        {
            return new SpanEnumerator<float, float, IdentityOperator<float>>(span, new()).Min(i => i);
        }

        public static double Min(this ReadOnlySpan<double> span)
        {
            return new SpanEnumerator<double, double, IdentityOperator<double>>(span, new()).Min(i => i);
        }

        public static decimal Min(this ReadOnlySpan<decimal> span)
        {
            return new SpanEnumerator<decimal, decimal, IdentityOperator<decimal>>(span, new()).Min(i => i);
        }

        public static int? Min(this ReadOnlySpan<int?> span)
        {
            return new SpanEnumerator<int?, int?, IdentityOperator<int?>>(span, new()).Min(i => i);
        }

        public static long? Min(this ReadOnlySpan<long?> span)
        {
            return new SpanEnumerator<long?, long?, IdentityOperator<long?>>(span, new()).Min(i => i);
        }

        public static float? Min(this ReadOnlySpan<float?> span)
        {
            return new SpanEnumerator<float?, float?, IdentityOperator<float?>>(span, new()).Min(i => i);
        }

        public static double? Min(this ReadOnlySpan<double?> span)
        {
            return new SpanEnumerator<double?, double?, IdentityOperator<double?>>(span, new()).Min(i => i);
        }

        public static decimal? Min(this ReadOnlySpan<decimal?> span)
        {
            return new SpanEnumerator<decimal?, decimal?, IdentityOperator<decimal?>>(span, new()).Min(i => i);
        }

        public static int Min<T>(this ReadOnlySpan<T> span, Func<T, int> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static long Min<T>(this ReadOnlySpan<T> span, Func<T, long> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static float Min<T>(this ReadOnlySpan<T> span, Func<T, float> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static double Min<T>(this ReadOnlySpan<T> span, Func<T, double> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static decimal Min<T>(this ReadOnlySpan<T> span, Func<T, decimal> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static int? Min<T>(this ReadOnlySpan<T> span, Func<T, int?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static long? Min<T>(this ReadOnlySpan<T> span, Func<T, long?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static float? Min<T>(this ReadOnlySpan<T> span, Func<T, float?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static double? Min<T>(this ReadOnlySpan<T> span, Func<T, double?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static decimal? Min<T>(this ReadOnlySpan<T> span, Func<T, decimal?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static T Min<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(i => i);
        }

        public static TResult Min<T, TResult>(this ReadOnlySpan<T> span, Func<T, TResult> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static TResult Min<T, TResult>(this ReadOnlySpan<T> span, Func<T, TResult> selector, IComparer<TResult> comparer)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector, comparer);
        }









        public static int Min(this Span<int> span)
        {
            return new SpanEnumerator<int, int, IdentityOperator<int>>(span, new()).Min(i => i);
        }

        public static long Min(this Span<long> span)
        {
            return new SpanEnumerator<long, long, IdentityOperator<long>>(span, new()).Min(i => i);
        }

        public static float Min(this Span<float> span)
        {
            return new SpanEnumerator<float, float, IdentityOperator<float>>(span, new()).Min(i => i);
        }

        public static double Min(this Span<double> span)
        {
            return new SpanEnumerator<double, double, IdentityOperator<double>>(span, new()).Min(i => i);
        }

        public static decimal Min(this Span<decimal> span)
        {
            return new SpanEnumerator<decimal, decimal, IdentityOperator<decimal>>(span, new()).Min(i => i);
        }

        public static int? Min(this Span<int?> span)
        {
            return new SpanEnumerator<int?, int?, IdentityOperator<int?>>(span, new()).Min(i => i);
        }

        public static long? Min(this Span<long?> span)
        {
            return new SpanEnumerator<long?, long?, IdentityOperator<long?>>(span, new()).Min(i => i);
        }

        public static float? Min(this Span<float?> span)
        {
            return new SpanEnumerator<float?, float?, IdentityOperator<float?>>(span, new()).Min(i => i);
        }

        public static double? Min(this Span<double?> span)
        {
            return new SpanEnumerator<double?, double?, IdentityOperator<double?>>(span, new()).Min(i => i);
        }

        public static decimal? Min(this Span<decimal?> span)
        {
            return new SpanEnumerator<decimal?, decimal?, IdentityOperator<decimal?>>(span, new()).Min(i => i);
        }

        public static int Min<T>(this Span<T> span, Func<T, int> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static long Min<T>(this Span<T> span, Func<T, long> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static float Min<T>(this Span<T> span, Func<T, float> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static double Min<T>(this Span<T> span, Func<T, double> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static decimal Min<T>(this Span<T> span, Func<T, decimal> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static int? Min<T>(this Span<T> span, Func<T, int?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static long? Min<T>(this Span<T> span, Func<T, long?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static float? Min<T>(this Span<T> span, Func<T, float?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static double? Min<T>(this Span<T> span, Func<T, double?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static decimal? Min<T>(this Span<T> span, Func<T, decimal?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static T Min<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(i => i);
        }

        public static TResult Min<T, TResult>(this Span<T> span, Func<T, TResult> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector);
        }

        public static TResult Min<T, TResult>(this Span<T> span, Func<T, TResult> selector, IComparer<TResult> comparer)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Min(selector, comparer);
        }





        public static int Min<T, TOperator>(this SpanEnumerator<T, int, TOperator> enumerator)
            where TOperator : ISpanOperator<T, int>
        {
            return enumerator.Min(i => i);
        }

        public static long Min<T, TOperator>(this SpanEnumerator<T, long, TOperator> enumerator)
           where TOperator : ISpanOperator<T, long>
        {
            return enumerator.Min(i => i);
        }

        public static float Min<T, TOperator>(this SpanEnumerator<T, float, TOperator> enumerator)
           where TOperator : ISpanOperator<T, float>
        {
            return enumerator.Min(i => i);
        }

        public static double Min<T, TOperator>(this SpanEnumerator<T, double, TOperator> enumerator)
           where TOperator : ISpanOperator<T, double>
        {
            return enumerator.Min(i => i);
        }

        public static decimal Min<T, TOperator>(this SpanEnumerator<T, decimal, TOperator> enumerator)
            where TOperator : ISpanOperator<T, decimal>
        {
            return enumerator.Min(i => i);
        }

        public static int? Min<T, TOperator>(this SpanEnumerator<T, int?, TOperator> enumerator)
            where TOperator : ISpanOperator<T, int?>
        {
            return enumerator.Min(i => i);
        }

        public static long? Min<T, TOperator>(this SpanEnumerator<T, long?, TOperator> enumerator)
           where TOperator : ISpanOperator<T, long?>
        {
            return enumerator.Min(i => i);
        }

        public static float? Min<T, TOperator>(this SpanEnumerator<T, float?, TOperator> enumerator)
           where TOperator : ISpanOperator<T, float?>
        {
            return enumerator.Min(i => i);
        }

        public static double? Min<T, TOperator>(this SpanEnumerator<T, double?, TOperator> enumerator)
           where TOperator : ISpanOperator<T, double?>
        {
            return enumerator.Min(i => i);
        }

        public static decimal? Min<T, TOperator>(this SpanEnumerator<T, decimal?, TOperator> enumerator)
            where TOperator : ISpanOperator<T, decimal?>
        {
            return enumerator.Min(i => i);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public int Min(Func<TOut, int> selector)
        {
            int count = 0;
            var Min = int.MaxValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return Min;
                }

                var value = selector(current);
                Min = Math.Min(value, Min);
                count++;
            }
        }

        public long Min(Func<TOut, long> selector)
        {
            int count = 0;
            var Min = long.MaxValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return Min;
                }

                var value = selector(current);
                Min = Math.Min(value, Min);
                count++;
            }
        }

        public float Min(Func<TOut, float> selector)
        {
            int count = 0;
            var Min = float.MaxValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return Min;
                }

                var value = selector(current);
                Min = Math.Min(value, Min);
                count++;
            }
        }

        public double Min(Func<TOut, double> selector)
        {
            int count = 0;
            var Min = double.MaxValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return Min;
                }

                var value = selector(current);
                Min = Math.Min(value, Min);
                count++;
            }
        }

        public decimal Min(Func<TOut, decimal> selector)
        {
            int count = 0;
            var Min = decimal.MaxValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return Min;
                }

                var value = selector(current);
                Min = Math.Min(value, Min);
                count++;
            }
        }



        public int? Min(Func<TOut, int?> selector)
        {
            int count = 0;
            var Min = int.MaxValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    return Min;
                }

                var value = selector(current);
                if (value != null)
                {
                    Min = Math.Min(value.Value, Min);
                    count++;
                }
            }
        }

        public long? Min(Func<TOut, long?> selector)
        {
            int count = 0;
            var Min = long.MaxValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    return Min;
                }

                var value = selector(current);
                if (value != null)
                {
                    Min = Math.Min(value.Value, Min);
                    count++;
                }
            }
        }

        public float? Min(Func<TOut, float?> selector)
        {
            int count = 0;
            var Min = float.MaxValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    return Min;
                }

                var value = selector(current);
                if (value != null)
                {
                    Min = Math.Min(value.Value, Min);
                    count++;
                }
            }
        }

        public double? Min(Func<TOut, double?> selector)
        {
            int count = 0;
            var Min = double.MaxValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    return Min;
                }

                var value = selector(current);
                if (value != null)
                {
                    Min = Math.Min(value.Value, Min);
                    count++;
                }
            }
        }

        public decimal? Min(Func<TOut, decimal?> selector)
        {
            int count = 0;
            var Min = decimal.MaxValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    return Min;
                }

                var value = selector(current);
                if (value != null)
                {
                    Min = Math.Min(value.Value, Min);
                    count++;
                }
            }
        }

        public TResult Min<TResult>(Func<TOut, TResult> selector)
        {
            TResult Min = default!;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    return Min;
                }

                var value = selector(current);
                if (value is IComparable<TResult> comparableGeneric)
                {
                    if (comparableGeneric.CompareTo(Min) > 0)
                    {
                        Min = value;
                    }
                }
                else if (value is IComparable comparable)
                {
                    if (comparable.CompareTo(Min) < 0)
                    {
                        Min = value;
                    }
                }
            }
        }

        public TResult Min<TResult>(Func<TOut, TResult> selector, IComparer<TResult>? comparer)
        {
            TResult Min = default!;
            comparer ??= Comparer<TResult>.Default;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    return Min;
                }

                var value = selector(current);
                if (comparer.Compare(value, Min) < 0)
                {
                    Min = value;
                }
            }
        }

    }
}
