using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class CountBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Count")]
        public int SpanCount()
        {
            return Range.AsSpan().Count();
        }

        [Benchmark, BenchmarkCategory("System", "Count")]
        public int SystemCount()
        {
            return Range.Count();
        }

        [Benchmark, BenchmarkCategory("Span", "Count")]
        public int SpanCountPredicate()
        {
            return Range.AsSpan().Count(i => i % 3 == 0);
        }

        [Benchmark, BenchmarkCategory("System", "Count")]
        public int SystemCountPredicate()
        {
            return Range.Count(i => i % 3 == 0);
        }
    }
}
