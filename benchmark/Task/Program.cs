using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Task
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = new AsyncVsSync();
            ThreadPool.SetMaxThreads(5, 5);

            var sw = new Stopwatch();

            sw.Start();
            var syncTasks = Enumerable.Range(0, 100)
                .Select(x => System.Threading.Tasks.Task.Factory.StartNew(s.SyncCode));
            System.Threading.Tasks.Task.WhenAll(syncTasks).Wait();
            Console.WriteLine($"not async {sw.ElapsedMilliseconds}");

            sw.Restart();
            var asyncTasks = Enumerable.Range(0, 100)
                .Select(x => s.AsyncCode());
            System.Threading.Tasks.Task.WhenAll(asyncTasks).Wait();

            Console.WriteLine($"async {sw.ElapsedMilliseconds}");
        }
    }

    public class AsyncVsSync
    {
        private WebClient.KeyValueStorage keyValueStorage;

        public int importantOperationIterations;
        public int syncCnt;
        public int asyncCnt;

        public AsyncVsSync()
        {
            keyValueStorage = new WebClient.KeyValueStorage();
        }

        public void SyncCode()
        {
            var tmp = Interlocked.Increment(ref syncCnt);
            Console.WriteLine($"sync {tmp} {DateTime.Now:O} {Thread.CurrentThread.ManagedThreadId}");

            var result = GetValueAsync().Result;

            Console.WriteLine($"sync middle {tmp} {DateTime.Now:O} {Thread.CurrentThread.ManagedThreadId}");

            DoVeryImportantWork();

            Console.WriteLine($"sync end {tmp} {DateTime.Now:O} {Thread.CurrentThread.ManagedThreadId}");
        }
        
        public async System.Threading.Tasks.Task AsyncCode()
        {
            var tmp = Interlocked.Increment(ref asyncCnt);
            Console.WriteLine($"async {tmp} {DateTime.Now:O} {Thread.CurrentThread.ManagedThreadId}");

            var result = await GetValueAsync().ConfigureAwait(false);

            Console.WriteLine($"async middle {tmp} {DateTime.Now:O} {Thread.CurrentThread.ManagedThreadId}");

            DoVeryImportantWork();

            Console.WriteLine($"async end {tmp} {DateTime.Now:O} {Thread.CurrentThread.ManagedThreadId}");
        }

        private int GetValueSync()
        {
            return keyValueStorage.Sleep();
        }

        private Task<int> GetValueAsync()
        {
            return keyValueStorage.SleepAsync();
        }

        private void DoVeryImportantWork()
        {
            for (int i = 1, k = 1; i < importantOperationIterations; i++)
            {
                k *= i;
            }
        }
    }
}