using NUnit.Framework;
using Task;
using Task.DontChange;

namespace Solves
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class SolvedTaskTests : StudentTaskTests
    {
        protected override void Setup()
        {
            Tracer.Clear();
            zooFactory = new SolvedZooFactory();
        }

    }
}