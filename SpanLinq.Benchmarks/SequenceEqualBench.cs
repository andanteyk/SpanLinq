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


        [Benchmark, BenchmarkCategory("Span", "SequenceEqual")]
        public bool SpanSequenceEqualSequence()
        {
            return SpanEnumerable.Range(0, Helper.DefaultSequenceLength).SequenceEqual(SpanEnumerable.Range(0, Helper.DefaultSequenceLength));
        }

        [Benchmark, BenchmarkCategory("System", "SequenceEqual")]
        public bool SystemSequenceEqualSequence()
        {
            return Enumerable.Range(0, Helper.DefaultSequenceLength).SequenceEqual(Enumerable.Range(0, Helper.DefaultSequenceLength));
        }
    }
}
