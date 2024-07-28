using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ZipBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Zip")]
        public void SpanZip()
        {
            // TODO: type inference
            Range.AsSpan().Zip<int, int>(Range).AsSpan().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Where")]
        public void SystemZip()
        {
            Range.Zip(Range).Consume(Helper.Consumer);
        }
    }
}
