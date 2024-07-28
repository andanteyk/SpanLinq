using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class AsEnumerableBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "AsEnumerable")]
        public void SpanAsEnumerable()
        {
            Range.AsSpan().AsEnumerable().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "AsEnumerable")]
        public void SystemAsEnumerable()
        {
            Range.AsEnumerable().Consume(Helper.Consumer);
        }
    }
}
