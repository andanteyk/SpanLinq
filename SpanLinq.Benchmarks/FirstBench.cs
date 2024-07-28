using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class FirstBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "First")]
        public int SpanFirst()
        {
            return Range.AsSpan().First(i => i == Helper.DefaultSequenceLength - 1);
        }

        [Benchmark, BenchmarkCategory("System", "First")]
        public int SystemFirst()
        {
            return Range.First(i => i == Helper.DefaultSequenceLength - 1);
        }
    }
}
