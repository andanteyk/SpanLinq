using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ConcatBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Concat")]
        public void SpanConcat()
        {
            Range.AsSpan().Concat(Range).ToEnumerator().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Concat")]
        public void SystemConcat()
        {
            Range.Concat(Range).Consume(Helper.Consumer);
        }
    }
}
