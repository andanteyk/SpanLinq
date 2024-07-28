using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class DistinctByBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "DistinctBy")]
        public void SpanDistinctBy()
        {
            Range.AsSpan().DistinctBy(i => i % 5).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "DistinctBy")]
        public void SystemDistinctBy()
        {
            Range.DistinctBy(i => i % 5).Consume(Helper.Consumer);
        }
    }
}
