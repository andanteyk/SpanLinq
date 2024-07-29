using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ToListBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ToList")]
        public List<int> SpanToList()
        {
            return Range.AsSpan().ToList();
        }

        [Benchmark, BenchmarkCategory("System", "ToList")]
        public List<int> SystemToList()
        {
            return Range.ToList();
        }
    }
}
