using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class OfTypeBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "OfType")]
        public void SpanOfType()
        {
            Range.AsSpan().OfType<int, int>().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "OfType")]
        public void SystemOfType()
        {
            Range.OfType<int>().Consume(Helper.Consumer);
        }
    }
}
