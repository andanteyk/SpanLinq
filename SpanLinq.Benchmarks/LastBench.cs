using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class LastBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Last")]
        public int SpanLast()
        {
            return Range.AsSpan().Last(i => i == 0);
        }

        [Benchmark, BenchmarkCategory("System", "Last")]
        public int SystemLast()
        {
            return Range.Last(i => i == 0);
        }
    }
}
