using NUnit.Framework;
using Tasks;

namespace Solves
{
    [TestFixture]
    public class SolvedTaskTests : StudentTaskTests
    {
        protected override void Setup()
        {
            task = new SolvedTask();
        }
    }
}