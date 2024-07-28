namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static int Sum(this ReadOnlySpan<int> span)
        {
            return new SpanEnumerator<int, int, IdentityOperator<int>>(span, new()).Sum(i => i);
        }

        public static long Sum(this ReadOnlySpan<long> span)
        {
            return new SpanEnumerator<long, long, IdentityOperator<long>>(span, new()).Sum(i => i);
        }

        public static float Sum(this ReadOnlySpan<float> span)
        {
            return new SpanEnumerator<float, float, IdentityOperator<float>>(span, new()).Sum(i => i);
        }

        public static double Sum(this ReadOnlySpan<double> span)
        {
            return new SpanEnumerator<double, double, IdentityOperator<double>>(span, new()).Sum(i => i);
        }

        public static decimal Sum(this ReadOnlySpan<decimal> span)
        {
            return new SpanEnumerator<decimal, decimal, IdentityOperator<decimal>>(span, new()).Sum(i => i);
        }


        public static int Sum(this ReadOnlySpan<int?> span)
        {
            return new SpanEnumerator<int?, int?, IdentityOperator<int?>>(span, new()).Sum(i => i);
        }

        public static long Sum(this ReadOnlySpan<long?> span)
        {
            return new SpanEnumerator<long?, long?, IdentityOperator<long?>>(span, new()).Sum(i => i);
        }

        public static float Sum(this ReadOnlySpan<float?> span)
        {
            return new SpanEnumerator<float?, float?, IdentityOperator<float?>>(span, new()).Sum(i => i);
        }

        public static double Sum(this ReadOnlySpan<double?> span)
        {
            return new SpanEnumerator<double?, double?, IdentityOperator<double?>>(span, new()).Sum(i => i);
        }

        public static decimal Sum(this ReadOnlySpan<decimal?> span)
        {
            return new SpanEnumerator<decimal?, decimal?, IdentityOperator<decimal?>>(span, new()).Sum(i => i);
        }


        public static int Sum<T>(this ReadOnlySpan<T> span, Func<T, int> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static long Sum<T>(this ReadOnlySpan<T> span, Func<T, long> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static float Sum<T>(this ReadOnlySpan<T> span, Func<T, float> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static double Sum<T>(this ReadOnlySpan<T> span, Func<T, double> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static decimal Sum<T>(this ReadOnlySpan<T> span, Func<T, decimal> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }


        public static int Sum<T>(this ReadOnlySpan<T> span, Func<T, int?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static long Sum<T>(this ReadOnlySpan<T> span, Func<T, long?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static float Sum<T>(this ReadOnlySpan<T> span, Func<T, float?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static double Sum<T>(this ReadOnlySpan<T> span, Func<T, double?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static decimal Sum<T>(this ReadOnlySpan<T> span, Func<T, decimal?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }


        // ---

        public static int Sum(this Span<int> span)
        {
            return new SpanEnumerator<int, int, IdentityOperator<int>>(span, new()).Sum(i => i);
        }

        public static long Sum(this Span<long> span)
        {
            return new SpanEnumerator<long, long, IdentityOperator<long>>(span, new()).Sum(i => i);
        }

        public static float Sum(this Span<float> span)
        {
            return new SpanEnumerator<float, float, IdentityOperator<float>>(span, new()).Sum(i => i);
        }

        public static double Sum(this Span<double> span)
        {
            return new SpanEnumerator<double, double, IdentityOperator<double>>(span, new()).Sum(i => i);
        }

        public static decimal Sum(this Span<decimal> span)
        {
            return new SpanEnumerator<decimal, decimal, IdentityOperator<decimal>>(span, new()).Sum(i => i);
        }


        public static int Sum(this Span<int?> span)
        {
            return new SpanEnumerator<int?, int?, IdentityOperator<int?>>(span, new()).Sum(i => i);
        }

        public static long Sum(this Span<long?> span)
        {
            return new SpanEnumerator<long?, long?, IdentityOperator<long?>>(span, new()).Sum(i => i);
        }

        public static float Sum(this Span<float?> span)
        {
            return new SpanEnumerator<float?, float?, IdentityOperator<float?>>(span, new()).Sum(i => i);
        }

        public static double Sum(this Span<double?> span)
        {
            return new SpanEnumerator<double?, double?, IdentityOperator<double?>>(span, new()).Sum(i => i);
        }

        public static decimal Sum(this Span<decimal?> span)
        {
            return new SpanEnumerator<decimal?, decimal?, IdentityOperator<decimal?>>(span, new()).Sum(i => i);
        }


        public static int Sum<T>(this Span<T> span, Func<T, int> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static long Sum<T>(this Span<T> span, Func<T, long> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static float Sum<T>(this Span<T> span, Func<T, float> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static double Sum<T>(this Span<T> span, Func<T, double> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static decimal Sum<T>(this Span<T> span, Func<T, decimal> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }


        public static int Sum<T>(this Span<T> span, Func<T, int?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static long Sum<T>(this Span<T> span, Func<T, long?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static float Sum<T>(this Span<T> span, Func<T, float?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static double Sum<T>(this Span<T> span, Func<T, double?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }

        public static decimal Sum<T>(this Span<T> span, Func<T, decimal?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Sum(selector);
        }


        // ----


        public static int Sum<TSource, TOpeartor>(this SpanEnumerator<TSource, int, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, int>
        {
            return spanEnumerator.Sum(i => i);
        }

        public static long Sum<TSource, TOpeartor>(this SpanEnumerator<TSource, long, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, long>
        {
            return spanEnumerator.Sum(i => i);
        }

        public static float Sum<TSource, TOpeartor>(this SpanEnumerator<TSource, float, TOpeartor> spanEnumerator)
                    where TOpeartor : ISpanOperator<TSource, float>
        {
            return spanEnumerator.Sum(i => i);
        }

        public static double Sum<TSource, TOpeartor>(this SpanEnumerator<TSource, double, TOpeartor> spanEnumerator)
                    where TOpeartor : ISpanOperator<TSource, double>
        {
            return spanEnumerator.Sum(i => i);
        }

        public static decimal Sum<TSource, TOpeartor>(this SpanEnumerator<TSource, decimal, TOpeartor> spanEnumerator)
                    where TOpeartor : ISpanOperator<TSource, decimal>
        {
            return spanEnumerator.Sum(i => i);
        }

        public static int Sum<TSource, TOpeartor>(this SpanEnumerator<TSource, int?, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, int?>
        {
            return spanEnumerator.Sum(i => i);
        }

        public static long Sum<TSource, TOpeartor>(this SpanEnumerator<TSource, long?, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, long?>
        {
            return spanEnumerator.Sum(i => i);
        }

        public static float Sum<TSource, TOpeartor>(this SpanEnumerator<TSource, float?, TOpeartor> spanEnumerator)
                    where TOpeartor : ISpanOperator<TSource, float?>
        {
            return spanEnumerator.Sum(i => i);
        }

        public static double Sum<TSource, TOpeartor>(this SpanEnumerator<TSource, double?, TOpeartor> spanEnumerator)
                    where TOpeartor : ISpanOperator<TSource, double?>
        {
            return spanEnumerator.Sum(i => i);
        }

        public static decimal Sum<TSource, TOpeartor>(this SpanEnumerator<TSource, decimal?, TOpeartor> spanEnumerator)
                    where TOpeartor : ISpanOperator<TSource, decimal?>
        {
            return spanEnumerator.Sum(i => i);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public int Sum(Func<TOut, int> selector)
        {
            int sum = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }
                int delta = selector(current);

                checked
                {
                    sum += delta;
                }
            }
            return sum;
        }

        public long Sum(Func<TOut, long> selector)
        {
            long sum = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }
                long delta = selector(current);

                checked
                {
                    sum += delta;
                }
            }
            return sum;
        }

        public float Sum(Func<TOut, float> selector)
        {
            float sum = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }
                float delta = selector(current);

                checked
                {
                    sum += delta;
                }
            }
            return sum;
        }

        public double Sum(Func<TOut, double> selector)
        {
            double sum = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }
                double delta = selector(current);

                checked
                {
                    sum += delta;
                }
            }
            return sum;
        }

        public decimal Sum(Func<TOut, decimal> selector)
        {
            decimal sum = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }
                decimal delta = selector(current);

                checked
                {
                    sum += delta;
                }
            }
            return sum;
        }

        public int Sum(Func<TOut, int?> selector)
        {
            int sum = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }
                int? delta = selector(current);

                if (delta.HasValue)
                {
                    checked
                    {
                        sum += delta.Value;
                    }
                }
            }
            return sum;
        }

        public long Sum(Func<TOut, long?> selector)
        {
            long sum = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }
                long? delta = selector(current);

                if (delta.HasValue)
                {
                    checked
                    {
                        sum += delta.Value;
                    }
                }
            }
            return sum;
        }

        public float Sum(Func<TOut, float?> selector)
        {
            float sum = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }
                float? delta = selector(current);

                if (delta.HasValue)
                {
                    checked
                    {
                        sum += delta.Value;
                    }
                }
            }
            return sum;
        }

        public double Sum(Func<TOut, double?> selector)
        {
            double sum = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }
                double? delta = selector(current);

                if (delta.HasValue)
                {
                    checked
                    {
                        sum += delta.Value;
                    }
                }
            }
            return sum;
        }

        public decimal Sum(Func<TOut, decimal?> selector)
        {
            decimal sum = 0;
            while (true)
            {
                var current = Operator.TryMoveNext(ref Source, out bool ok);
                if (!ok)
                {
                    break;
                }
                decimal? delta = selector(current);

                if (delta.HasValue)
                {
                    checked
                    {
                        sum += delta.Value;
                    }
                }
            }
            return sum;
        }
    }
}
