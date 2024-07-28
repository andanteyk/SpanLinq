using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class SequenceEqualBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "SequenceEqual")]
        public bool SpanSequenceEqual()
        {
            return Range.AsSpan().SequenceEqual(Range);
        }

        [Benchmark, BenchmarkCategory("System", "SequenceEqual")]
        public bool SystemSequenceEqual()
        {
            return Range.SequenceEqual(Range);
        }
    }
}
