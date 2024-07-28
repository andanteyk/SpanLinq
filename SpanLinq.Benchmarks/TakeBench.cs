using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class TakeBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Take")]
        public void SpanTake()
        {
            Range.AsSpan().Take(Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Take")]
        public void SystemTake()
        {
            Range.Take(Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }
    }
}
