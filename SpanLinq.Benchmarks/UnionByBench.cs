using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class UnionByBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "UnionBy")]
        public void SpanUnionBy()
        {
            Range.AsSpan().UnionBy(Range, i => i).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "UnionBy")]
        public void SystemUnionBy()
        {
            Range.UnionBy(Range, i => i).Consume(Helper.Consumer);
        }
    }
}
