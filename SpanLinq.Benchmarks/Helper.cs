using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace SpanLinq.Benchmarks
{
    public static class Helper
    {
        public static readonly int DefaultSequenceLength = 1024;

        public static readonly Consumer Consumer = new();

        public static void Consume<TSource, TOut, TOperator>(this SpanEnumerator<TSource, TOut, TOperator> spanEnumerator, Consumer consumer)
            where TOperator : ISpanOperator<TSource, TOut>
        {
            while (true)
            {
                var current = spanEnumerator.Yield(out bool ok);
                if (!ok)
                {
                    break;
                }
                consumer.Consume(current);
            }
        }
    }
}
