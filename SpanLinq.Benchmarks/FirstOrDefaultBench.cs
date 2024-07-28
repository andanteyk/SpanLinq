using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class FirstOrDefaultBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "FirstOrDefault")]
        public int SpanFirstOrDefault()
        {
            return Range.AsSpan().FirstOrDefault(i => i == Helper.DefaultSequenceLength - 1);
        }

        [Benchmark, BenchmarkCategory("System", "FirstOrDefault")]
        public int SystemFirstOrDefault()
        {
            return Range.FirstOrDefault(i => i == Helper.DefaultSequenceLength - 1);
        }
    }
}
