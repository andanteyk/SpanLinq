using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class LastOrDefaultBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "LastOrDefault")]
        public int SpanLastOrDefault()
        {
            return Range.AsSpan().LastOrDefault(i => i == 0);
        }

        [Benchmark, BenchmarkCategory("System", "LastOrDefault")]
        public int SystemLastOrDefault()
        {
            return Range.LastOrDefault(i => i == 0);
        }
    }
}
