using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ExceptByBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ExceptBy")]
        public void SpanExceptBy()
        {
            Range.AsSpan().ExceptBy(Range, i => i % 12).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "ExceptBy")]
        public void SystemExceptBy()
        {
            Range.ExceptBy(Range, i => i % 12).Consume(Helper.Consumer);
        }
    }
}
