using Documentation.Api;
using Documentation.Descriptior;

namespace Documentation.Common
{
    [TestFixture]
    public class TestBase
    {
        protected IDescriptor<VkApi> descriptor;

        [SetUp]
        protected virtual void Setup()
        {
            descriptor = new Descriptor();
        }
    }
}