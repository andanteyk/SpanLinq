using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class JoinBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Join")]
        public void SpanJoin()
        {
            // TODO: some error in type inference?
            Range.AsSpan().Join<int, int, int, int>(Range, i => i, i => i, (a, b) => a).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Join")]
        public void SystemJoin()
        {
            Range.Join(Range, i => i, i => i, (a, b) => a).Consume(Helper.Consumer);
        }
    }
}
