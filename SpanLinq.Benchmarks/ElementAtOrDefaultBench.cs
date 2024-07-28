using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class ElementAtOrDefaultBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ElementAt")]
        public int SpanElementAtOrDefault()
        {
            return Range.AsSpan().ElementAtOrDefault(^1);
        }

        [Benchmark, BenchmarkCategory("System", "ElementAt")]
        public int SystemElementAtOrDefault()
        {
            return Range.ElementAtOrDefault(^1);
        }
    }
}
