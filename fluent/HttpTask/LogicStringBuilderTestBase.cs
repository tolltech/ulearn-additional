using NUnit.Framework;

namespace EncapsulationTask
{
    [TestFixture]
    public abstract class LogicStringBuilderTestBase
    {
        protected abstract ILogicStringBuilder CreateStringBuilder(string str);
    }
}