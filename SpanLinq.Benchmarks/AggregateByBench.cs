using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Microsoft.CodeAnalysis.Emit;

namespace SpanLinq.Benchmarks
{
    public class AggregateByBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "AggregateBy")]
        public void SpanAggregateBy()
        {
            Range.AsSpan().AggregateBy(i => i % 3, 0, (current, next) => current + next).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "AggregateBy")]
        public void SystemAggregateBy()
        {
            Enumerable.AggregateBy(Range, i => i % 3, 0, (current, next) => current + next).Consume(Helper.Consumer);
        }
    }
}
