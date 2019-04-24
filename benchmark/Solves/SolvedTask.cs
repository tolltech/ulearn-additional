using BenchmarkDotNet.Attributes;
using System;
using System.Threading.Tasks;
using Task;
using Task.WebClient;

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

    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class AsyncVsSync
    {
        private KeyValueStorage keyValueStorage;

        [Params(10000000)]
        public int importantOperationIterations;

        [GlobalSetup]
        public void Setup()
        {
            keyValueStorage = new KeyValueStorage();
        }

        [Benchmark]
        public void SyncCode()
        {
            var result = GetValueSync();
            DoVeryImportantWork();
        }

        [Benchmark]
        public void AsyncCode()
        {
            var result = GetValueAsync();
            DoVeryImportantWork();
        }

        private int GetValueSync()
        {
            return keyValueStorage.Sleep();
        }

        private async Task<int> GetValueAsync()
        {
            
            return await System.Threading.Tasks.Task.Run(() => keyValueStorage.Sleep());
        }

        private void DoVeryImportantWork()
        {
            for (int i = 0, k = 0; i < importantOperationIterations; i++)
            {
                k += i;
            }
        }
    }
}