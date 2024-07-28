using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class WhereBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Where")]
        public void SpanWhere()
        {
            Range.AsSpan().Where(i => i % 3 == 0).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Where")]
        public void SystemWhere()
        {
            Range.Where(i => i % 3 == 0).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("Handcrafted", "Where")]
        public int[] HandcraftedWhere()
        {
            var result = new int[Helper.DefaultSequenceLength / 2];
            int p = 0;
            for (int i = 0; i < Helper.DefaultSequenceLength; i++)
            {
                if (i % 2 == 0)
                {
                    result[p++] = i;
                }
            }
            return result;
        }
    }
}
