using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class ForEachBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "ForEach")]
        public void SpanForEach()
        {
            Range.AsSpan().ForEach(i => Helper.Consumer.Consume(i));
        }
    }
}
