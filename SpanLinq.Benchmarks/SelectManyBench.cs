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
            Range.AsSpan().SelectMany(input => SpanEnumerable.Range(0, Helper.DefaultSequenceLength)).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "SelectMany")]
        public void SystemSelectMany()
        {
            Range.SelectMany(i => Enumerable.Range(0, Helper.DefaultSequenceLength)).Consume(Helper.Consumer);
        }
    }
}
