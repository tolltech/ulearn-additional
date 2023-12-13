// using System;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading;
// using BenchmarkDotNet.Attributes;
// using BenchmarkDotNet.Columns;
// using BenchmarkDotNet.Configs;
// using BenchmarkDotNet.Exporters;
// using BenchmarkDotNet.Exporters.Csv;
// using BenchmarkDotNet.Running;
// using NUnit.Framework;
//
// namespace Solves
// {
//     [Config(typeof(ExampleConfig))]
//     public class DotNetBenchmarkExample
//     {
//         private class ExampleConfig : ManualConfig
//         {
//             public ExampleConfig()
//             {
//                 Add(StatisticColumn.Max); // Добавляем необходимую колонку 
//                 Add(RPlotExporter.Default, CsvExporter.Default);
//                 WithOption(ConfigOptions.DisableOptimizationsValidator, true);
//             }
//         }
//
//         [Params(10, 100, 1000, 10000)] public int count;
//
//         [Benchmark(Description = "Sum")]
//         public int TestSum()
//         {
//             return Enumerable.Range(1, count).Sum();
//         }
//     }
//
//     [TestFixture]
//     class TestBenchmark
//     {
//         [Test]
//         public void Test()
//         {
//             BenchmarkRunner.Run<DotNetBenchmarkExample>();
//         }
//     }
// }