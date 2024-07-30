using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class UnionBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Union")]
        public void SpanUnion()
        {
            Range.AsSpan().Union(Range).ToEnumerator().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Union")]
        public void SystemUnion()
        {
            Range.Union(Range).Consume(Helper.Consumer);
        }
    }
}
