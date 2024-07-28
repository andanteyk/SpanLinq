
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using SpanLinq.Benchmarks;

var config = DefaultConfig.Instance
    .AddDiagnoser(MemoryDiagnoser.Default)
    .AddValidator(ExecutionValidator.FailOnError)
    .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.Default, MethodOrderPolicy.Alphabetical))
    .WithOption(ConfigOptions.JoinSummary, true);

BenchmarkRunner.Run(typeof(Program).Assembly, config);


