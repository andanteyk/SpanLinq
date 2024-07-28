using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ToLookupBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ToLookup")]
        public void SpanToLookup()
        {
            Range.AsSpan().ToLookup(i => i).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "ToLookup")]
        public void SystemToLookup()
        {
            Range.ToLookup(i => i).Consume(Helper.Consumer);
        }
    }
}
