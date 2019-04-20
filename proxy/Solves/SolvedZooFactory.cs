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
            var lazyBones = Proxy.CreateProxy<Lazybones>(invocation =>
            {
                var stopwatch = new Stopwatch();

                stopwatch.Start();
                var result = invocation.Proceed();
                stopwatch.Stop();

                var method = invocation.Method;
                var arguments = invocation.Arguments;
                var spentMilliseconds = (int) stopwatch.ElapsedMilliseconds;
                Tracer.LogTrace(
                    $"{method?.DeclaringType?.Name} {method?.Name} {arguments.FirstOrDefault()} milliseconds",
                    spentMilliseconds);
                return result;
            });
            var animals = new []{lazyBones}.Cast<Animal>().ToArray();
            return new Zoo(animals);
        }
    }
}