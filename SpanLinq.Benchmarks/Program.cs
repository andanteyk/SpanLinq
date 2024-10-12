
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Filters;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

var config = DefaultConfig.Instance
//    .AddFilter(new AnyCategoriesFilter(new string[] { "Join" }))
    .AddDiagnoser(MemoryDiagnoser.Default)
    .AddValidator(ExecutionValidator.FailOnError)
    .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Alphabetical))
    .WithOption(ConfigOptions.JoinSummary, true);

BenchmarkRunner.Run(typeof(Program).Assembly, config);