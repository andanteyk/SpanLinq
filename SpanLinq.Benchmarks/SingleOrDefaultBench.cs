using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class SingleOrDefaultBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "SingleOrDefault")]
        public int SpanSingleOrDefault()
        {
            return Range.AsSpan().SingleOrDefault(i => i == Helper.DefaultSequenceLength - 1);
        }

        [Benchmark, BenchmarkCategory("System", "SingleOrDefault")]
        public int SystemSingleOrDefault()
        {
            return Range.SingleOrDefault(i => i == Helper.DefaultSequenceLength - 1);
        }
    }
}
