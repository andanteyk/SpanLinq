using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class MinBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Min")]
        public int SpanMin()
        {
            return Range.AsSpan().Min();
        }

        [Benchmark, BenchmarkCategory("System", "Min")]
        public int SystemMin()
        {
            return Range.Min();
        }
    }
}
