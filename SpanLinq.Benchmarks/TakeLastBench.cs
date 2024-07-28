using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class TakeLastBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "TakeLast")]
        public void SpanTakeLast()
        {
            Range.AsSpan().TakeLast(Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "TakeLast")]
        public void SystemTakeLast()
        {
            Range.TakeLast(Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }
    }
}
