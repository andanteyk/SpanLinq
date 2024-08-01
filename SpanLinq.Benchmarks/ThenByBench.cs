using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ThenByBench
    {
        private (int, int)[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).Index().ToArray();

        [Benchmark, BenchmarkCategory("Span", "ThenBy")]
        public void SpanThenBy()
        {
            Range.AsSpan().OrderBy(i => i.Item1).ThenBy(i => i.Item2).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "ThenBy")]
        public void SystemThenBy()
        {
            Range.OrderBy(i => i.Item1).ThenBy(i => i.Item2).Consume(Helper.Consumer);
        }


        [Benchmark, BenchmarkCategory("Span", "ThenByDescending")]
        public void SpanThenByDescending()
        {
            Range.AsSpan().OrderBy(i => i.Item1).ThenByDescending(i => i.Item2).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "ThenByDescending")]
        public void SystemThenByDescending()
        {
            Range.OrderBy(i => i.Item1).ThenByDescending(i => i.Item2).Consume(Helper.Consumer);
        }
    }
}
