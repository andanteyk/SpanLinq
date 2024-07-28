using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class ContainsBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Contains")]
        public bool SpanContains()
        {
            return Range.AsSpan().Contains(Helper.DefaultSequenceLength - 1);
        }

        [Benchmark, BenchmarkCategory("System", "Contains")]
        public bool SystemContains()
        {
            return Range.Contains(Helper.DefaultSequenceLength - 1);
        }

        [Benchmark, BenchmarkCategory("Handcrafted", "Contains")]
        public bool HandcraftedContains()
        {
            return MemoryExtensions.Contains(Range, Helper.DefaultSequenceLength - 1);
        }
    }
}
