using BenchmarkDotNet.Running;

namespace Task
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BubbleSortVsCountSort>();
        }
    }
}