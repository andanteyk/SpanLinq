using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class GroupByBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "GroupBy")]
        public void SpanGroupBy()
        {
            Range.AsSpan().GroupBy(i => i % 60).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "GroupBy")]
        public void SystemGroupBy()
        {
            Range.GroupBy(i => i % 60).Consume(Helper.Consumer);
        }
    }
}
