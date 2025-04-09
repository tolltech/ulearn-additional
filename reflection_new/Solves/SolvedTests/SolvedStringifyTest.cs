using Stringify;

namespace Solves.SolvedTests
{
    [TestFixture]
    public class SolvedStringifyTest : GreatClassTests
    {
        protected override void SetUp()
        {
            base.SetUp();
            customConvert = new SolvedCustomConvert();
        }
    }
}