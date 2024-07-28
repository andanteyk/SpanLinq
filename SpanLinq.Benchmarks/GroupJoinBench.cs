using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class GroupJoinBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "GroupJoin")]
        public void SpanGroupJoin()
        {
            Range.AsSpan().GroupJoin(Range, i => i, i => i, (int key, IEnumerable<int> result) => key).Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "GroupJoin")]
        public void SystemGroupJoin()
        {
            Range.GroupJoin(Range, i => i, i => i, (int key, IEnumerable<int> result) => key).Consume(Helper.Consumer);
        }
    }
}
