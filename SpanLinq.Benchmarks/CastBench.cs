using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public class CastBench
    {
        private int[] Range = Enumerable.Range(0, Helper.DefaultSequenceLength).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Cast")]
        public void SpanCastIntToObject()
        {
            Range.AsSpan().Cast<int, object>().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("Span", "Cast")]
        public void SpanCastIntToNullableInt()
        {
            Range.AsSpan().Cast<int, int?>().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Cast")]
        public void SystemCastIntToObject()
        {
            Range.Cast<object>().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Cast")]
        public void SystemCastIntToNullableInt()
        {
            Range.Cast<int?>().Consume(Helper.Consumer);
        }


        private record class MyBase(int Value) { }
        private record class MyDerived(int Value) : MyBase(Value) { }
        private MyDerived[] MyRange = Enumerable.Range(0, Helper.DefaultSequenceLength).Select(i => new MyDerived(i)).ToArray();

        [Benchmark, BenchmarkCategory("Span", "Cast")]
        public void SpanCastClass()
        {
            MyRange.AsSpan().Cast<MyDerived, MyBase>().Consume(Helper.Consumer);
        }

        [Benchmark, BenchmarkCategory("System", "Cast")]
        public void SystemCastClass()
        {
            MyRange.Cast<MyBase>().Consume(Helper.Consumer);
        }

    }
}
