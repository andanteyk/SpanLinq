using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class SelectManyBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "SelectMany")]
        public void SpanSelectMany()
        {
            // TODO: type inference
            Range.AsSpan().SelectMany<int, int>(input => Range.AsSpan()).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "SelectMany")]
        public void SystemSelectMany()
        {
            Range.SelectMany(i => Range).Consume(Helper.Consumer);
        }
    }
}
