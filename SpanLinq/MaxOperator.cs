namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static int Max(this ReadOnlySpan<int> span)
        {
            return new SpanEnumerator<int, int, IdentityOperator<int>>(span, new()).Max(i => i);
        }

        public static long Max(this ReadOnlySpan<long> span)
        {
            return new SpanEnumerator<long, long, IdentityOperator<long>>(span, new()).Max(i => i);
        }

        public static float Max(this ReadOnlySpan<float> span)
        {
            return new SpanEnumerator<float, float, IdentityOperator<float>>(span, new()).Max(i => i);
        }

        public static double Max(this ReadOnlySpan<double> span)
        {
            return new SpanEnumerator<double, double, IdentityOperator<double>>(span, new()).Max(i => i);
        }

        public static decimal Max(this ReadOnlySpan<decimal> span)
        {
            return new SpanEnumerator<decimal, decimal, IdentityOperator<decimal>>(span, new()).Max(i => i);
        }

        public static int? Max(this ReadOnlySpan<int?> span)
        {
            return new SpanEnumerator<int?, int?, IdentityOperator<int?>>(span, new()).Max(i => i);
        }

        public static long? Max(this ReadOnlySpan<long?> span)
        {
            return new SpanEnumerator<long?, long?, IdentityOperator<long?>>(span, new()).Max(i => i);
        }

        public static float? Max(this ReadOnlySpan<float?> span)
        {
            return new SpanEnumerator<float?, float?, IdentityOperator<float?>>(span, new()).Max(i => i);
        }

        public static double? Max(this ReadOnlySpan<double?> span)
        {
            return new SpanEnumerator<double?, double?, IdentityOperator<double?>>(span, new()).Max(i => i);
        }

        public static decimal? Max(this ReadOnlySpan<decimal?> span)
        {
            return new SpanEnumerator<decimal?, decimal?, IdentityOperator<decimal?>>(span, new()).Max(i => i);
        }

        public static int Max<T>(this ReadOnlySpan<T> span, Func<T, int> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static long Max<T>(this ReadOnlySpan<T> span, Func<T, long> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static float Max<T>(this ReadOnlySpan<T> span, Func<T, float> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static double Max<T>(this ReadOnlySpan<T> span, Func<T, double> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static decimal Max<T>(this ReadOnlySpan<T> span, Func<T, decimal> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static int? Max<T>(this ReadOnlySpan<T> span, Func<T, int?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static long? Max<T>(this ReadOnlySpan<T> span, Func<T, long?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static float? Max<T>(this ReadOnlySpan<T> span, Func<T, float?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static double? Max<T>(this ReadOnlySpan<T> span, Func<T, double?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static decimal? Max<T>(this ReadOnlySpan<T> span, Func<T, decimal?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static T Max<T>(this ReadOnlySpan<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(i => i);
        }

        public static TResult Max<T, TResult>(this ReadOnlySpan<T> span, Func<T, TResult> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static TResult Max<T, TResult>(this ReadOnlySpan<T> span, Func<T, TResult> selector, IComparer<TResult> comparer)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector, comparer);
        }









        public static int Max(this Span<int> span)
        {
            return new SpanEnumerator<int, int, IdentityOperator<int>>(span, new()).Max(i => i);
        }

        public static long Max(this Span<long> span)
        {
            return new SpanEnumerator<long, long, IdentityOperator<long>>(span, new()).Max(i => i);
        }

        public static float Max(this Span<float> span)
        {
            return new SpanEnumerator<float, float, IdentityOperator<float>>(span, new()).Max(i => i);
        }

        public static double Max(this Span<double> span)
        {
            return new SpanEnumerator<double, double, IdentityOperator<double>>(span, new()).Max(i => i);
        }

        public static decimal Max(this Span<decimal> span)
        {
            return new SpanEnumerator<decimal, decimal, IdentityOperator<decimal>>(span, new()).Max(i => i);
        }

        public static int? Max(this Span<int?> span)
        {
            return new SpanEnumerator<int?, int?, IdentityOperator<int?>>(span, new()).Max(i => i);
        }

        public static long? Max(this Span<long?> span)
        {
            return new SpanEnumerator<long?, long?, IdentityOperator<long?>>(span, new()).Max(i => i);
        }

        public static float? Max(this Span<float?> span)
        {
            return new SpanEnumerator<float?, float?, IdentityOperator<float?>>(span, new()).Max(i => i);
        }

        public static double? Max(this Span<double?> span)
        {
            return new SpanEnumerator<double?, double?, IdentityOperator<double?>>(span, new()).Max(i => i);
        }

        public static decimal? Max(this Span<decimal?> span)
        {
            return new SpanEnumerator<decimal?, decimal?, IdentityOperator<decimal?>>(span, new()).Max(i => i);
        }

        public static int Max<T>(this Span<T> span, Func<T, int> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static long Max<T>(this Span<T> span, Func<T, long> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static float Max<T>(this Span<T> span, Func<T, float> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static double Max<T>(this Span<T> span, Func<T, double> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static decimal Max<T>(this Span<T> span, Func<T, decimal> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static int? Max<T>(this Span<T> span, Func<T, int?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static long? Max<T>(this Span<T> span, Func<T, long?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static float? Max<T>(this Span<T> span, Func<T, float?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static double? Max<T>(this Span<T> span, Func<T, double?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static decimal? Max<T>(this Span<T> span, Func<T, decimal?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static T Max<T>(this Span<T> span)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(i => i);
        }

        public static TResult Max<T, TResult>(this Span<T> span, Func<T, TResult> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector);
        }

        public static TResult Max<T, TResult>(this Span<T> span, Func<T, TResult> selector, IComparer<TResult> comparer)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Max(selector, comparer);
        }





        public static int Max<T, TOperator>(this SpanEnumerator<T, int, TOperator> enumerator)
            where TOperator : ISpanOperator<T, int>
        {
            return enumerator.Max(i => i);
        }

        public static long Max<T, TOperator>(this SpanEnumerator<T, long, TOperator> enumerator)
           where TOperator : ISpanOperator<T, long>
        {
            return enumerator.Max(i => i);
        }

        public static float Max<T, TOperator>(this SpanEnumerator<T, float, TOperator> enumerator)
           where TOperator : ISpanOperator<T, float>
        {
            return enumerator.Max(i => i);
        }

        public static double Max<T, TOperator>(this SpanEnumerator<T, double, TOperator> enumerator)
           where TOperator : ISpanOperator<T, double>
        {
            return enumerator.Max(i => i);
        }

        public static decimal Max<T, TOperator>(this SpanEnumerator<T, decimal, TOperator> enumerator)
            where TOperator : ISpanOperator<T, decimal>
        {
            return enumerator.Max(i => i);
        }

        public static int? Max<T, TOperator>(this SpanEnumerator<T, int?, TOperator> enumerator)
            where TOperator : ISpanOperator<T, int?>
        {
            return enumerator.Max(i => i);
        }

        public static long? Max<T, TOperator>(this SpanEnumerator<T, long?, TOperator> enumerator)
           where TOperator : ISpanOperator<T, long?>
        {
            return enumerator.Max(i => i);
        }

        public static float? Max<T, TOperator>(this SpanEnumerator<T, float?, TOperator> enumerator)
           where TOperator : ISpanOperator<T, float?>
        {
            return enumerator.Max(i => i);
        }

        public static double? Max<T, TOperator>(this SpanEnumerator<T, double?, TOperator> enumerator)
           where TOperator : ISpanOperator<T, double?>
        {
            return enumerator.Max(i => i);
        }

        public static decimal? Max<T, TOperator>(this SpanEnumerator<T, decimal?, TOperator> enumerator)
            where TOperator : ISpanOperator<T, decimal?>
        {
            return enumerator.Max(i => i);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public int Max(Func<TOut, int> selector)
        {
            int count = 0;
            var max = int.MinValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return max;
                }

                var value = selector(current);
                max = Math.Max(value, max);
                count++;
            }
        }

        public long Max(Func<TOut, long> selector)
        {
            int count = 0;
            var max = long.MinValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return max;
                }

                var value = selector(current);
                max = Math.Max(value, max);
                count++;
            }
        }

        public float Max(Func<TOut, float> selector)
        {
            int count = 0;
            var max = float.MinValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return max;
                }

                var value = selector(current);
                max = Math.Max(value, max);
                count++;
            }
        }

        public double Max(Func<TOut, double> selector)
        {
            int count = 0;
            var max = double.MinValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return max;
                }

                var value = selector(current);
                max = Math.Max(value, max);
                count++;
            }
        }

        public decimal Max(Func<TOut, decimal> selector)
        {
            int count = 0;
            var max = decimal.MinValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return max;
                }

                var value = selector(current);
                max = Math.Max(value, max);
                count++;
            }
        }



        public int? Max(Func<TOut, int?> selector)
        {
            int count = 0;
            var max = int.MinValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    return max;
                }

                var value = selector(current);
                if (value != null)
                {
                    max = Math.Max(value.Value, max);
                    count++;
                }
            }
        }

        public long? Max(Func<TOut, long?> selector)
        {
            int count = 0;
            var max = long.MinValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    return max;
                }

                var value = selector(current);
                if (value != null)
                {
                    max = Math.Max(value.Value, max);
                    count++;
                }
            }
        }

        public float? Max(Func<TOut, float?> selector)
        {
            int count = 0;
            var max = float.MinValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    return max;
                }

                var value = selector(current);
                if (value != null)
                {
                    max = Math.Max(value.Value, max);
                    count++;
                }
            }
        }

        public double? Max(Func<TOut, double?> selector)
        {
            int count = 0;
            var max = double.MinValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    return max;
                }

                var value = selector(current);
                if (value != null)
                {
                    max = Math.Max(value.Value, max);
                    count++;
                }
            }
        }

        public decimal? Max(Func<TOut, decimal?> selector)
        {
            int count = 0;
            var max = decimal.MinValue;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    return max;
                }

                var value = selector(current);
                if (value != null)
                {
                    max = Math.Max(value.Value, max);
                    count++;
                }
            }
        }

        public TResult Max<TResult>(Func<TOut, TResult> selector)
        {
            TResult max = default!;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    return max;
                }

                var value = selector(current);
                if (value is IComparable<TResult> comparableGeneric)
                {
                    if (comparableGeneric.CompareTo(max) > 0)
                    {
                        max = value;
                    }
                }
                else if (value is IComparable comparable)
                {
                    if (comparable.CompareTo(max) > 0)
                    {
                        max = value;
                    }
                }
            }
        }

        public TResult Max<TResult>(Func<TOut, TResult> selector, IComparer<TResult>? comparer)
        {
            TResult max = default!;
            comparer ??= Comparer<TResult>.Default;

            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    return max;
                }

                var value = selector(current);
                if (comparer.Compare(value, max) > 0)
                {
                    max = value;
                }
            }
        }

    }
}
