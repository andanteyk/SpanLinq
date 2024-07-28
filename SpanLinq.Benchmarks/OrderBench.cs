using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class OrderBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Order")]
        public void SpanOrder()
        {
            Range.AsSpan().Order().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Order")]
        public void SystemOrder()
        {
            Range.Order().Consume(Helper.Consumer);
        }


        [Benchmark, BenchmarkCategory("Span", "OrderDescending")]
        public void SpanOrderByDescending()
        {
            Range.AsSpan().OrderDescending().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "OrderDescending")]
        public void SystemOrderByDescending()
        {
            Range.OrderDescending().Consume(Helper.Consumer);
        }
    }
}
