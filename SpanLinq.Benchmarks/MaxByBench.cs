using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class MaxByBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "MaxBy")]
        public long SpanMaxBy()
        {
            return Range.AsSpan().MaxBy(i => i);
        }

        [Benchmark, BenchmarkCategory("System", "MaxBy")]
        public long SystemMaxBy()
        {
            return Range.MaxBy(i => i);
        }
    }
}
