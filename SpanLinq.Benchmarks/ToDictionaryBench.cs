using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ToDictionaryBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ToDictionary")]
        public void SpanToDictionary()
        {
            Range.AsSpan().ToDictionary(i => i).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "ToDictionary")]
        public void SystemToDictionary()
        {
            Range.ToDictionary(i => i).Consume(Helper.Consumer);
        }
    }
}
