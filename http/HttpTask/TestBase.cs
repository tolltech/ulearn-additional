using NUnit.Framework;

namespace EncapsulationTask
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        protected virtual void Setup()
        {
        }
    }
}