using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class PrependBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Prepend")]
        public void SpanPrepend()
        {
            Range.AsSpan().Prepend(-1).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Prepend")]
        public void SystemPrepend()
        {
            Range.Prepend(-1).Consume(Helper.Consumer);
        }
    }
}
