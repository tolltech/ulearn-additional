using System.Diagnostics;
using System.Linq;
using SexyProxy;
using Task;
using Task.DontChange;

namespace Solves
{
    public class SolvedZooFactory : IZooFactory
    {
        public IZoo CreateZoo()
        {
            var lazyBones = CreateAnimal<Lazybones>();
            var elephant = CreateAnimal<Elephant>();
            var monkey = CreateAnimal<Monkey>();
            var animals = new [] {lazyBones, elephant, monkey}.ToArray();
            return new Zoo(animals);
        }

        private static Animal CreateAnimal<T>() where T : Animal
        {
            return Proxy.CreateProxy<T>(invocation =>
            {
                var stopwatch = new Stopwatch();

                stopwatch.Start();
                var result = invocation.Proceed();
                stopwatch.Stop();

                var method = invocation.Method;
                var arguments = invocation.Arguments;
                var spentMilliseconds = (int) stopwatch.ElapsedMilliseconds;

                Tracer.LogTrace(
                    $"{method?.DeclaringType?.Name} {method?.Name} {arguments.FirstOrDefault()} milliseconds and have made some {result.Result}",
                    spentMilliseconds);

                return result;
            });
        }
    }
}