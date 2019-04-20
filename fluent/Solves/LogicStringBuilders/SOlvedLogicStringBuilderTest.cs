using EncapsulationTask;

namespace Solves.LogicStringBuilders
{
    public class SolvedLogicStringBuilderTest : LogicStringBuilderTestBase
    {
        protected override ILogicStringBuilder CreateStringBuilder(string str)
        {
            return new LogicStringBuilderSolved(str);
        }
    }
}