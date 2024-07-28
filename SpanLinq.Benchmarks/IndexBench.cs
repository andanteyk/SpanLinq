using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class IndexBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Index")]
        public void SpanIndex()
        {
            Range.AsSpan().Index().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Index")]
        public void SystemIndex()
        {
            Range.Index().Consume(Helper.Consumer);
        }
    }
}
