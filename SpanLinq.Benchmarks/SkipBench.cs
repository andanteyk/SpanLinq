using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class SkipBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Skip")]
        public void SpanSkip()
        {
            Range.AsSpan().Skip(Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Skip")]
        public void SystemSkip()
        {
            Range.Skip(Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }
    }
}
