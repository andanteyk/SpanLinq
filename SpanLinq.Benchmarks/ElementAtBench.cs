using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class ElementAtBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ElementAt")]
        public int SpanElementAt()
        {
            return Range.AsSpan().ElementAt(^1);
        }

        [Benchmark, BenchmarkCategory("System", "ElementAt")]
        public int SystemElementAt()
        {
            return Range.ElementAt(^1);
        }
    }
}
