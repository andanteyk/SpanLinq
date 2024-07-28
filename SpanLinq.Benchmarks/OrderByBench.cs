using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class OrderByBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "OrderBy")]
        public void SpanOrderBy()
        {
            // TODO: it will be same as `Order`, so you should consider an another plan
            Range.AsSpan().OrderBy(i => i).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "OrderBy")]
        public void SystemOrderBy()
        {
            Range.OrderBy(i => i).Consume(Helper.Consumer);
        }


        [Benchmark, BenchmarkCategory("Span", "OrderByDescending")]
        public void SpanOrderByDescending()
        {
            // TODO: it will be same as `Order`, so you should consider an another plan
            Range.AsSpan().OrderByDescending(i => i).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "OrderByDescending")]
        public void SystemOrderByDescending()
        {
            Range.OrderByDescending(i => i).Consume(Helper.Consumer);
        }
    }
}
