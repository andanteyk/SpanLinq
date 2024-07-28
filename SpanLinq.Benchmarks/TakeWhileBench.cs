using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class TakeWhileBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "TakeWhile")]
        public void SpanTakeWhile()
        {
            Range.AsSpan().TakeWhile(i => i < Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "TakeWhile")]
        public void SystemTakeWhile()
        {
            Range.TakeWhile(i => i < Helper.DefaultSequenceLength - 1).Consume(Helper.Consumer);
        }
    }
}
