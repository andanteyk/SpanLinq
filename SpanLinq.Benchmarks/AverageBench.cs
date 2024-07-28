using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class AverageBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Average")]
        public double SpanAverage()
        {
            return Range.AsSpan().Average();
        }

        [Benchmark, BenchmarkCategory("System", "Average")]
        public double SystemAverage()
        {
            return Range.Average();
        }
    }
}
