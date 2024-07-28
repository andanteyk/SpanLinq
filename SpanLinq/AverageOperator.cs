namespace SpanLinq
{
    public static partial class SpanEnumerable
    {
        public static double Average(this ReadOnlySpan<int> span)
        {
            return new SpanEnumerator<int, int, IdentityOperator<int>>(span, new()).Average(i => i);
        }

        public static double Average(this ReadOnlySpan<long> span)
        {
            return new SpanEnumerator<long, long, IdentityOperator<long>>(span, new()).Average(i => i);
        }

        public static float Average(this ReadOnlySpan<float> span)
        {
            return new SpanEnumerator<float, float, IdentityOperator<float>>(span, new()).Average(i => i);
        }

        public static double Average(this ReadOnlySpan<double> span)
        {
            return new SpanEnumerator<double, double, IdentityOperator<double>>(span, new()).Average(i => i);
        }

        public static decimal Average(this ReadOnlySpan<decimal> span)
        {
            return new SpanEnumerator<decimal, decimal, IdentityOperator<decimal>>(span, new()).Average(i => i);
        }


        public static double? Average(this ReadOnlySpan<int?> span)
        {
            return new SpanEnumerator<int?, int?, IdentityOperator<int?>>(span, new()).Average(i => i);
        }

        public static double? Average(this ReadOnlySpan<long?> span)
        {
            return new SpanEnumerator<long?, long?, IdentityOperator<long?>>(span, new()).Average(i => i);
        }

        public static float? Average(this ReadOnlySpan<float?> span)
        {
            return new SpanEnumerator<float?, float?, IdentityOperator<float?>>(span, new()).Average(i => i);
        }

        public static double? Average(this ReadOnlySpan<double?> span)
        {
            return new SpanEnumerator<double?, double?, IdentityOperator<double?>>(span, new()).Average(i => i);
        }

        public static decimal? Average(this ReadOnlySpan<decimal?> span)
        {
            return new SpanEnumerator<decimal?, decimal?, IdentityOperator<decimal?>>(span, new()).Average(i => i);
        }


        public static double Average<T>(this ReadOnlySpan<T> span, Func<T, int> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static double Average<T>(this ReadOnlySpan<T> span, Func<T, long> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static float Average<T>(this ReadOnlySpan<T> span, Func<T, float> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static double Average<T>(this ReadOnlySpan<T> span, Func<T, double> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static decimal Average<T>(this ReadOnlySpan<T> span, Func<T, decimal> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }


        public static double? Average<T>(this ReadOnlySpan<T> span, Func<T, int?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static double? Average<T>(this ReadOnlySpan<T> span, Func<T, long?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static float? Average<T>(this ReadOnlySpan<T> span, Func<T, float?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static double? Average<T>(this ReadOnlySpan<T> span, Func<T, double?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static decimal? Average<T>(this ReadOnlySpan<T> span, Func<T, decimal?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }



        public static double Average(this Span<int> span)
        {
            return new SpanEnumerator<int, int, IdentityOperator<int>>(span, new()).Average(i => i);
        }

        public static double Average(this Span<long> span)
        {
            return new SpanEnumerator<long, long, IdentityOperator<long>>(span, new()).Average(i => i);
        }

        public static float Average(this Span<float> span)
        {
            return new SpanEnumerator<float, float, IdentityOperator<float>>(span, new()).Average(i => i);
        }

        public static double Average(this Span<double> span)
        {
            return new SpanEnumerator<double, double, IdentityOperator<double>>(span, new()).Average(i => i);
        }

        public static decimal Average(this Span<decimal> span)
        {
            return new SpanEnumerator<decimal, decimal, IdentityOperator<decimal>>(span, new()).Average(i => i);
        }


        public static double? Average(this Span<int?> span)
        {
            return new SpanEnumerator<int?, int?, IdentityOperator<int?>>(span, new()).Average(i => i);
        }

        public static double? Average(this Span<long?> span)
        {
            return new SpanEnumerator<long?, long?, IdentityOperator<long?>>(span, new()).Average(i => i);
        }

        public static float? Average(this Span<float?> span)
        {
            return new SpanEnumerator<float?, float?, IdentityOperator<float?>>(span, new()).Average(i => i);
        }

        public static double? Average(this Span<double?> span)
        {
            return new SpanEnumerator<double?, double?, IdentityOperator<double?>>(span, new()).Average(i => i);
        }

        public static decimal? Average(this Span<decimal?> span)
        {
            return new SpanEnumerator<decimal?, decimal?, IdentityOperator<decimal?>>(span, new()).Average(i => i);
        }


        public static double Average<T>(this Span<T> span, Func<T, int> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static double Average<T>(this Span<T> span, Func<T, long> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static float Average<T>(this Span<T> span, Func<T, float> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static double Average<T>(this Span<T> span, Func<T, double> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static decimal Average<T>(this Span<T> span, Func<T, decimal> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }


        public static double? Average<T>(this Span<T> span, Func<T, int?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static double? Average<T>(this Span<T> span, Func<T, long?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static float? Average<T>(this Span<T> span, Func<T, float?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static double? Average<T>(this Span<T> span, Func<T, double?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }

        public static decimal? Average<T>(this Span<T> span, Func<T, decimal?> selector)
        {
            return new SpanEnumerator<T, T, IdentityOperator<T>>(span, new()).Average(selector);
        }




        public static double Average<TSource, TOpeartor>(this SpanEnumerator<TSource, int, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, int>
        {
            return spanEnumerator.Average(i => i);
        }

        public static double Average<TSource, TOpeartor>(this SpanEnumerator<TSource, long, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, long>
        {
            return spanEnumerator.Average(i => i);
        }

        public static float Average<TSource, TOpeartor>(this SpanEnumerator<TSource, float, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, float>
        {
            return spanEnumerator.Average(i => i);
        }

        public static double Average<TSource, TOpeartor>(this SpanEnumerator<TSource, double, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, double>
        {
            return spanEnumerator.Average(i => i);
        }

        public static decimal Average<TSource, TOpeartor>(this SpanEnumerator<TSource, decimal, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, decimal>
        {
            return spanEnumerator.Average(i => i);
        }


        public static double? Average<TSource, TOpeartor>(this SpanEnumerator<TSource, int?, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, int?>
        {
            return spanEnumerator.Average(i => i);
        }

        public static double? Average<TSource, TOpeartor>(this SpanEnumerator<TSource, long?, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, long?>
        {
            return spanEnumerator.Average(i => i);
        }

        public static float? Average<TSource, TOpeartor>(this SpanEnumerator<TSource, float?, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, float?>
        {
            return spanEnumerator.Average(i => i);
        }

        public static double? Average<TSource, TOpeartor>(this SpanEnumerator<TSource, double?, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, double?>
        {
            return spanEnumerator.Average(i => i);
        }

        public static decimal? Average<TSource, TOpeartor>(this SpanEnumerator<TSource, decimal?, TOpeartor> spanEnumerator)
            where TOpeartor : ISpanOperator<TSource, decimal?>
        {
            return spanEnumerator.Average(i => i);
        }
    }

    partial struct SpanEnumerator<TSource, TOut, TOperator>
    {
        public double Average(Func<TOut, int> selector)
        {
            long sum = 0;
            int count = 0;
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
                count++;
            }

            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            return (double)sum / count;
        }

        public double Average(Func<TOut, long> selector)
        {
            long sum = 0;
            int count = 0;
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
                count++;
            }

            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            return (double)sum / count;
        }

        public float Average(Func<TOut, float> selector)
        {
            float sum = 0;
            int count = 0;
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
                count++;
            }

            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            return sum / count;
        }

        public double Average(Func<TOut, double> selector)
        {
            double sum = 0;
            int count = 0;
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
                count++;
            }

            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            return sum / count;
        }

        public decimal Average(Func<TOut, decimal> selector)
        {
            decimal sum = 0;
            int count = 0;
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
                count++;
            }

            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            return sum / count;
        }



        public double? Average(Func<TOut, int?> selector)
        {
            long sum = 0;
            int count = 0;
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
                    count++;
                }
            }

            if (count == 0)
            {
                return null;
            }
            return (double)sum / count;
        }

        public double? Average(Func<TOut, long?> selector)
        {
            long sum = 0;
            int count = 0;
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
                    count++;
                }
            }

            if (count == 0)
            {
                return null;
            }
            return (double)sum / count;
        }

        public float? Average(Func<TOut, float?> selector)
        {
            float sum = 0;
            int count = 0;
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
                    count++;
                }
            }

            if (count == 0)
            {
                return null;
            }
            return sum / count;
        }

        public double? Average(Func<TOut, double?> selector)
        {
            double sum = 0;
            int count = 0;
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
                    count++;
                }
            }

            if (count == 0)
            {
                return null;
            }
            return sum / count;
        }

        public decimal? Average(Func<TOut, decimal?> selector)
        {
            decimal sum = 0;
            int count = 0;
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
                    count++;
                }
            }

            if (count == 0)
            {
                return null;
            }
            return sum / count;
        }
    }
}
