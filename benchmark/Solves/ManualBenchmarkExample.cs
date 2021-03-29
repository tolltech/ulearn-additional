using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Solves
{
    public class ManualBenchmarkExample
    {
        //1. Запускаем Release mode without debugging
        public void Run()
        {
            //2. Прогрев кеша процессора
            for (int i = 0; i < 5; i++)
            {
                TestSum();
            }
            //3. Запуск на одном процессоре
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            //4. Stopwatch, а не DateTime
            var stopwatch = new Stopwatch();
            //5. Высокий приоритет приложения
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            //6. Сборка мусора
            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            stopwatch.Start();
            TestSum(); // Можно сделать много прогонов и получить среднее
            stopwatch.Stop();
            Console.WriteLine($"{nameof(TestSum)}\t{stopwatch.ElapsedTicks} ticks");
        }
        
        public int TestSum()
        {
            return Enumerable.Range(1, 10000).Sum();
        }
    }

    [TestFixture]
    class Test
    {
        [Test]
        public void METHOD()
        {
            var manualBenchmarkExample = new ManualBenchmarkExample();
            manualBenchmarkExample.Run();
        }
    }
}