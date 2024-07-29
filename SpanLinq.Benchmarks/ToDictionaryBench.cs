using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class ToDictionaryBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ToDictionary")]
        public Dictionary<int, int> SpanToDictionary()
        {
            return Range.AsSpan().ToDictionary(i => i);
        }

        [Benchmark, BenchmarkCategory("System", "ToDictionary")]
        public Dictionary<int, int> SystemToDictionary()
        {
            return Range.ToDictionary(i => i);
        }
    }
}
