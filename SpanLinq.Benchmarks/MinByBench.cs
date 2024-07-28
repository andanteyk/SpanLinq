using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class MinByBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "MinBy")]
        public long SpanMinBy()
        {
            return Range.AsSpan().MinBy(i => i);
        }

        [Benchmark, BenchmarkCategory("System", "MinBy")]
        public long SystemMinBy()
        {
            return Range.MinBy(i => i);
        }
    }
}
