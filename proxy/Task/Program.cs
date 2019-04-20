using System;
using System.Diagnostics;
using System.Linq;
using SexyProxy;
using Task.DontChange;

namespace Task
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var lazyBones = Proxy.CreateProxy<Lazybones>(invocation =>
            {
                var stopwatch = new Stopwatch();

                stopwatch.Start();
                var result = invocation.Proceed();
                stopwatch.Stop();

                Console.WriteLine(result.Result);

                var method = invocation.Method;
                var arguments = invocation.Arguments;
                var spentMilliseconds = (int) stopwatch.ElapsedMilliseconds;
                Tracer.LogTrace(
                    $"{method?.DeclaringType?.Name} {method?.Name} {arguments.FirstOrDefault()} milliseconds",
                    spentMilliseconds);
                return result;
            });

            var task = new Zoo(new[] {lazyBones});
            task.SpendTime();
        }
    }
}