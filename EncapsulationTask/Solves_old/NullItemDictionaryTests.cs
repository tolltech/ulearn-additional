using EncapsulationTask_old;
using NUnit.Framework;

namespace Solves_old
{
    [TestFixture]
    public class NullItemDictionaryTests : EncapsulationTask_old.NullItemDictionaryTests
    {
        protected override void Setup()
        {
            sut = new NullItemDictionarySolved<string, string>();
            sutInt = new NullItemDictionarySolved<int, string>();
        }
    }
}