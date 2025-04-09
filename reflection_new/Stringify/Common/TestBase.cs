namespace Stringify.Common
{
    [TestFixture]
    public class TestBase
    {
        protected IGreatClass greatClass;

        [SetUp]
        protected virtual void SetUp()
        {
            greatClass = new GreatClass();
        }
    }
}