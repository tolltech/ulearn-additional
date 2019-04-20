using Documentation;
using NUnit.Framework;
using Solves.SolvedClasses;

namespace Solves.SolvedTests
{
    [TestFixture]
    public class SolvedDescriptorTest : DescriptorTests
    {
        protected override void Setup()
        {
            descriptor = new RightDescriptor();
        }
    }
}