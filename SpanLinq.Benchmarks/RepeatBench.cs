using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class RepeatBench
    {
        [Benchmark, BenchmarkCategory("Span", "Repeat")]
        public void SpanRepeat()
        {
            SpanEnumerable.Repeat(0, Helper.DefaultSequenceLength).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Repeat")]
        public void SystemRepeat()
        {
            Enumerable.Repeat(0, Helper.DefaultSequenceLength).Consume(Helper.Consumer);
        }
    }
}
