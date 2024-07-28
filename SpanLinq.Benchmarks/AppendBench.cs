using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class AppendBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Append")]
        public void SpanAppend()
        {
            Range.AsSpan().Append(-1).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Append")]
        public void SystemAppend()
        {
            Range.Append(-1).Consume(Helper.Consumer);
        }
    }
}
