using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class AllBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "All")]
        public bool SpanAll()
        {
            return Range.AsSpan().All(i => i >= 0);
        }

        [Benchmark, BenchmarkCategory("System", "All")]
        public bool SystemAll()
        {
            return Range.All(i => i >= 0);
        }
    }
}
