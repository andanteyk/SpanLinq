using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ChunkBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Chunk")]
        public void SpanChunk()
        {
            Range.AsSpan().Chunk(10).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Chunk")]
        public void SystemChunk()
        {
            Range.Chunk(10).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("Handcrafted", "Chunk")]
        public int[][] HandcraftedChunk()
        {
            var result = new int[Helper.DefaultSequenceLength / 10 + 1][];
            int hi = 0, lo = 0;
            for (int i = 0; i < Helper.DefaultSequenceLength; i++)
            {
                if (lo == 0)
                {
                    result[hi] = new int[10];
                }
                result[hi][lo++] = i;

                if (lo >= 10)
                {
                    lo = 0;
                }
            }
            return result;
        }
    }
}
