using ParallelTask;

namespace ParallelSolves
{
    [TestFixture]
    public class SolvedParallelCalculatorTests : ParallelCalculatorTests
    {
        protected override IParallelCalculator GetParallelCalculator() => new SolvedParallelCalculator();

        protected override void Setup()
        {
            parallelCalculator = new SolvedParallelCalculator();
        }
    }
}