using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class LongCountBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "LongCount")]
        public long SpanLongCount()
        {
            return Range.AsSpan().LongCount();
        }

        [Benchmark, BenchmarkCategory("System", "LongCount")]
        public long SystemLongCount()
        {
            return Range.LongCount();
        }

        [Benchmark, BenchmarkCategory("Span", "LongCount")]
        public long SpanLongCountPredicate()
        {
            return Range.AsSpan().LongCount(i => i % 3 == 0);
        }

        [Benchmark, BenchmarkCategory("System", "LongCount")]
        public long SystemLongCountPredicate()
        {
            return Range.LongCount(i => i % 3 == 0);
        }
    }
}
