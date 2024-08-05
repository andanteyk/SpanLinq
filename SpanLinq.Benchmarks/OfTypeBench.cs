using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class OfTypeBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "OfType")]
        public void SpanOfTypeIntToObject()
        {
            Range.AsSpan().OfType<int, object>().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "OfType")]
        public void SystemOfTypeIntToObject()
        {
            Range.OfType<object>().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("Span", "OfType")]
        public void SpanOfTypeIntToNullableInt()
        {
            Range.AsSpan().OfType<int, int?>().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "OfType")]
        public void SystemOfTypeIntToNullableInt()
        {
            Range.OfType<int?>().Consume(Helper.Consumer);
        }


        private record class MyBase(int Value) { }
        private record class MyDerived(int Value) : MyBase(Value) { }
        private MyDerived[] MyRange = Enumerable.Range(0, Helper.DefaultSequenceLength).Select(i => new MyDerived(i)).ToArray();

        [Benchmark, BenchmarkCategory("Span", "OfType")]
        public void SpanOfTypeClass()
        {
            MyRange.AsSpan().OfType<MyDerived, MyBase>().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "OfType")]
        public void SystemOfTypeClass()
        {
            MyRange.OfType<MyBase>().Consume(Helper.Consumer);
        }
    }
}
