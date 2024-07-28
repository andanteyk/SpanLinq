using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class RangeBench
    {
        [Benchmark, BenchmarkCategory("Span", "Range")]
        public void SpanRange()
        {
            SpanEnumerable.Range(0, Helper.DefaultSequenceLength).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Range")]
        public void SystemRange()
        {
            Enumerable.Range(0, Helper.DefaultSequenceLength).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("Handcrafted", "Range")]
        public int[] HandcraftedRange()
        {
            var values = new int[1024];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = i;
            }
            return values;
        }
    }
}