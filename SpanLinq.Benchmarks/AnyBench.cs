using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class AnyBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Any")]
        public bool SpanAny()
        {
            return Range.AsSpan().Any(i => i < 0);
        }

        [Benchmark, BenchmarkCategory("System", "Any")]
        public bool SystemAny()
        {
            return Range.Any(i => i < 0);
        }
    }
}
