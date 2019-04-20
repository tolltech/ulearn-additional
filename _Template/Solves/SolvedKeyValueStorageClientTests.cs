using NUnit.Framework;
using Task;

namespace Solves
{
    [TestFixture]
    public class SolvedKeyValueStorageClientTests : StudentTaskTests
    {
        protected override void Setup()
        {
            task = new SolvedTask();
        }
    }
}