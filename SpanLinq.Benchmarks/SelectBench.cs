using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class SelectBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Select")]
        public void SpanSelect()
        {
            Range.AsSpan().Select(i => (long)i).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Select")]
        public void SystemSelect()
        {
            Range.Select(i => (long)i).Consume(Helper.Consumer);
        }
    }
}
