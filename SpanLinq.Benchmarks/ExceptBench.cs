using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ExceptBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Except")]
        public void SpanExcept()
        {
            Range.AsSpan().Except(Range).ToEnumerator().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Except")]
        public void SystemExcept()
        {
            Range.Except(Range).Consume(Helper.Consumer);
        }
    }
}
