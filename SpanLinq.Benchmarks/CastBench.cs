using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class CastBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Cast")]
        public void SpanCast()
        {
            Range.AsSpan().Cast<int, int?>().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Cast")]
        public void SystemCast()
        {
            Range.Cast<int?>().Consume(Helper.Consumer);
        }
    }
}
