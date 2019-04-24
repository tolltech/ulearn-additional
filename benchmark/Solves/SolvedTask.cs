using BenchmarkDotNet.Attributes;
using System;
using Task;

namespace Solves
{
    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class BubbleSortVsCountSort
    {
        private int[] collection;

        [Params(10, 100)]
        public int collectionLength;

        [GlobalSetup]
        public void Setup()
        {
            collection = new int[collectionLength];
            FillCollection();
        }

        private void FillCollection()
        {
            var random = new Random(42);

            for (var i = 0; i < collectionLength; i++)
            {
                collection[i] = random.Next(10);
            }
        }

        [Benchmark]
        public void BubbleSort() => MySorter.BubbleSort(collection);

        [Benchmark]
        public void CountSort() => MySorter.CountingSort(collection, 0, 10);
    }
}