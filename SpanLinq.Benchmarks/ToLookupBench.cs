using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ToLookupBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ToLookup")]
        public ILookup<int, int> SpanToLookup()
        {
            return Range.AsSpan().ToLookup(i => i);
        }

        [Benchmark, BenchmarkCategory("System", "ToLookup")]
        public ILookup<int, int> SystemToLookup()
        {
            return Range.ToLookup(i => i);
        }
    }
}
