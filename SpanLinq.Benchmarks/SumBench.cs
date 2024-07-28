using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class SumBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Sum")]
        public int SpanSum()
        {
            return Range.AsSpan().Sum();
        }

        [Benchmark, BenchmarkCategory("System", "Sum")]
        public int SystemSum()
        {
            return Range.Sum();
        }
    }
}
