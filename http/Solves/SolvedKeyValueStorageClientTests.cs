using EncapsulationTask;
using NUnit.Framework;

namespace Solves
{
    [TestFixture]
    public class SolvedKeyValueStorageClientTests : KeyValueStorageClientTests
    {
        protected override void Setup()
        {
            client = new SolvedKeyValueStorage();
        }
    }
}