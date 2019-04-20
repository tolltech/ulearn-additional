using EncapsulationTask;
using NUnit.Framework;

namespace Solves
{
    [TestFixture]
    public class NullItemDictionaryTests : EncapsulationTask.NullItemDictionaryTests
    {
        protected override void Setup()
        {
            sut = new NullItemDictionarySolved<string, string>();
            sutInt = new NullItemDictionarySolved<int, string>();
        }
    }
}