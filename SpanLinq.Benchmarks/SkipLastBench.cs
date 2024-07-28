using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class SkipLastBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "SkipLast")]
        public void SpanSkipLast()
        {
            Range.AsSpan().SkipLast(Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "SkipLast")]
        public void SystemSkipLast()
        {
            Range.SkipLast(Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }
    }
}
