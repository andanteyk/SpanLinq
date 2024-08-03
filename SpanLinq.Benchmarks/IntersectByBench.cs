using System.Buffers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class IntersectByBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "IntersectBy")]
        public void SpanIntersectBy()
        {
            Range.AsSpan().IntersectBy(Range, i => i).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "IntersectBy")]
        public void SystemIntersectBy()
        {
            Range.IntersectBy(Range, i => i).Consume(Helper.Consumer);
        }
    }
}
