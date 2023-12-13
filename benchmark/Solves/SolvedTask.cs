using BenchmarkDotNet.Attributes;
using System;
using System.Linq;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using NUnit.Framework;
using Task;

namespace Solves;

[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net472)]
[SimpleJob(RuntimeMoniker.Net60)]
[RPlotExporter, MarkdownExporter, HtmlExporter]
[Config(typeof(ExampleConfig))]
public class BubbleSortVsCountSort
{
    private class ExampleConfig : ManualConfig
    {
        public ExampleConfig()
        {
            //AddColumn(StatisticColumn.Max);
            WithOption(ConfigOptions.DisableOptimizationsValidator, true);
        }
    }

    private int[] _collection;

    [Params(10, 100)] public int CollectionLength;

    [GlobalSetup]
    public void Setup()
    {
        _collection = new int[CollectionLength];
        FillCollection();
    }

    private void FillCollection()
    {
        var random = new Random(42);

        for (var i = 0; i < CollectionLength; i++)
        {
            _collection[i] = random.Next(10);
        }
    }

    [Benchmark]
    public void BubbleSort() => MySorter.BubbleSort(_collection);

    [Benchmark]
    public void CountSort() => MySorter.CountingSort(_collection, 0, 10);

    [Benchmark(Baseline = true)]
    public void LinqSort() => _collection.OrderBy(x => x).ToArray();
}

[TestFixture]
class TestSolvedBenchmark
{
    [Test]
    public void Test()
    {
        BenchmarkRunner.Run<BubbleSortVsCountSort>();
    }
}