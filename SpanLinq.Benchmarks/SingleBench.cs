using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class SingleBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Single")]
        public int SpanSingle()
        {
            return Range.AsSpan().Single(i => i == Helper.DefaultSequenceLength - 1);
        }

        [Benchmark, BenchmarkCategory("System", "Single")]
        public int SystemSingle()
        {
            return Range.Single(i => i == Helper.DefaultSequenceLength - 1);
        }
    }
}
