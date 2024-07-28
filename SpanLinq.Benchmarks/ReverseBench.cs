using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ReverseBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Reverse")]
        public void SpanReverse()
        {
            Range.AsSpan().Reverse().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Reverse")]
        public void SystemReverse()
        {
            Range.Reverse().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("Handcrafted", "Reverse")]
        public int[] HandcraftedReverse()
        {
            var result = new int[Helper.DefaultSequenceLength];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Helper.DefaultSequenceLength - 1 - i;
            }
            return result;
        }
    }
}
