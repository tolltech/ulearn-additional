using NUnit.Framework;
using Solves.SolvedClasses;
using Stringify;

namespace Solves.SolvedTests
{
    [TestFixture]
    public class SolvedStringifyTest : GreatClassTests
    {
        protected override void SetUp()
        {
            greatClass = new RightGreatClass();
        }
    }
}