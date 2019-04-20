using NUnit.Framework;

namespace Task
{
    [TestFixture]
    public abstract class TestBase
    {
        [SetUp]
        protected virtual void Setup()
        {            
        }
    }
}