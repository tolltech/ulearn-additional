using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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