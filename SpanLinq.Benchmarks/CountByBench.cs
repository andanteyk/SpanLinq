using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class CountByBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "CountBy")]
        public void SpanCountBy()
        {
            Range.AsSpan().CountBy(i => i % 3).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "CountBy")]
        public void SystemCountBy()
        {
            Range.CountBy(i => i % 3).Consume(Helper.Consumer);
        }

    }
}
