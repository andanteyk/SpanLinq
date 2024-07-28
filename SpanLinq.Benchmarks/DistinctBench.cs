using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class DistinctBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Distinct")]
        public void SpanDistinct()
        {
            Range.AsSpan().Distinct().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Distinct")]
        public void SystemDistinct()
        {
            Range.Distinct().Consume(Helper.Consumer);
        }
    }
}
