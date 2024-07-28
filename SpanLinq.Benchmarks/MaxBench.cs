using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class MaxBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Max")]
        public int SpanMax()
        {
            return Range.AsSpan().Max();
        }

        [Benchmark, BenchmarkCategory("System", "Max")]
        public int SystemMax()
        {
            return Range.Max();
        }
    }
}
