using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class IntersectBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Intersect")]
        public void SpanIntersect()
        {
            Range.AsSpan().Intersect(Range).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Intersect")]
        public void SystemIntersect()
        {
            Range.Intersect(Range).Consume(Helper.Consumer);
        }
    }
}
