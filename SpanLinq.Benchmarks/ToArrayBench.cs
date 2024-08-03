using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class ToArrayBench
    {
        [Benchmark, BenchmarkCategory("Span", "ToArray")]
        public int[] SpanToArray()
        {
            return SpanEnumerable.Range(0, Helper.DefaultSequenceLength).ToArray();
        }

        [Benchmark, BenchmarkCategory("System", "ToArray")]
        public int[] SystemToArray()
        {
            return Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();
        }
    }
}
