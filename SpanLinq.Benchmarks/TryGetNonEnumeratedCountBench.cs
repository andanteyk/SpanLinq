using BenchmarkDotNet.Attributes;

namespace SpanLinq.Benchmarks
{
    public class TryGetNonEnumeratedCountBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "TryGetNonEnumeratedCount")]
        public bool SpanTryGetNonEnumeratedCount()
        {
            return Range.AsSpan().TryGetNonEnumeratedCount(out _);
        }

        [Benchmark, BenchmarkCategory("System", "TryGetNonEnumeratedCount")]
        public bool SystemTryGetNonEnumeratedCount()
        {
            return Range.TryGetNonEnumeratedCount(out _);
        }
    }
}
