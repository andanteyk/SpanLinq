using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ToHashSetBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ToHashSet")]
        public HashSet<int> SpanToHashSet()
        {
            return Range.AsSpan().ToHashSet();
        }

        [Benchmark, BenchmarkCategory("System", "ToHashSet")]
        public HashSet<int> SystemToHashSet()
        {
            return Range.ToHashSet();
        }
    }
}
