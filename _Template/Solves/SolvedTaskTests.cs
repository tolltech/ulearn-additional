using NUnit.Framework;
using Task;

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