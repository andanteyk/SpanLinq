using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class SkipWhileBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "SkipWhile")]
        public void SpanSkipWhile()
        {
            Range.AsSpan().SkipWhile(i => i < Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "SkipWhile")]
        public void SystemSkipWhile()
        {
            Range.SkipWhile(i => i < Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }
    }
}
