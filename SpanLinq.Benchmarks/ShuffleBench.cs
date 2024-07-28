using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class ShuffleBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Shuffle")]
        public void SpanShuffle()
        {
            Range.AsSpan().Shuffle().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("Handcrafted", "Shuffle")]
        public void HandcraftedShuffle()
        {
            var random = Random.Shared;

            for (int i = 1; i < Range.Length; i++)
            {
                int r = random.Next(i + 1);
                (Range[i], Range[r]) = (Range[r], Range[i]);
            }
        }
    }
}
