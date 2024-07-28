using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class AggregateBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Aggregate")]
        public int SpanAggregate()
        {
            return Range.AsSpan().Aggregate((current, next) => current + next);
        }

        [Benchmark, BenchmarkCategory("System", "Aggregate")]
        public int SystemAggregate()
        {
            return Range.Aggregate((current, next) => current + next);
        }
    }
}
