using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ToHashSetBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ToHashSet")]
        public void SpanToHashSet()
        {
            Range.AsSpan().ToHashSet().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "ToHashSet")]
        public void SystemToHashSet()
        {
            Range.ToHashSet().Consume(Helper.Consumer);
        }
    }
}
