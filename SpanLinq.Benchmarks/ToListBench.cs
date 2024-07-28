using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ToListBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ToList")]
        public void SpanToList()
        {
            Range.AsSpan().ToList().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "ToList")]
        public void SystemToList()
        {
            Range.ToList().Consume(Helper.Consumer);
        }
    }
}
