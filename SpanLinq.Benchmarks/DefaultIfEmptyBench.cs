using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class DefaultIfEmptyBench
    {
        [Benchmark, BenchmarkCategory("Span", "DefaultIfEmpty")]
        public void SpanDefaultIfEmpty()
        {
            SpanEnumerable.Empty<int>().DefaultIfEmpty().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "DefaultIfEmpty")]
        public void SystemDefaultIfEmpty()
        {
            Enumerable.Empty<int>().DefaultIfEmpty().Consume(Helper.Consumer);
        }
    }
}
