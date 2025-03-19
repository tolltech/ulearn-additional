using System.Diagnostics;
using System.Net;
using FluentAssertions;

namespace ParallelTask
{
    public class ParallelCalculatorTests : TestBase
    {
        protected IParallelCalculator parallelCalculator;

        protected override void Setup()
        {
            parallelCalculator = GetParallelCalculator();
        }

        private static readonly int[] inputSmall = { 12, 23, 12, 20, 1, 7, 8, 9, 5 };

        private static readonly int[] inputBig =
            Enumerable.Range(0, 20000000).Select(_ => Guid.NewGuid().GetHashCode() % 100).ToArray();

        private static readonly int sumSmall = inputSmall.Sum();
        private static readonly int sumBig = inputBig.Sum();

        protected virtual IParallelCalculator GetParallelCalculator() => new ParallelCalculator();
        
        [Test]
        public void TestSumMonoSmall()
        {
            parallelCalculator.SumMono(inputSmall).Should().Be(sumSmall);
        }
        
        [Test]
        public void TestSumMonoBig()
        {
            parallelCalculator.SumMono(inputBig).Should().Be(sumBig);
        }

        [Test]
        [TestCaseSource(nameof(GetTestCases))]
        public void TestCheckSmallSum(Func<IParallelCalculator, int[], int> testFunc)
        {
            testFunc(GetParallelCalculator(), inputSmall).Should().Be(sumSmall);
        }
        
        [Test]
        [TestCaseSource(nameof(GetTestCases))]
        public void TestCheckBigSum(Func<IParallelCalculator, int[], int> testFunc)
        {
            testFunc(GetParallelCalculator(), inputBig).Should().Be(sumBig);
        }

        [Test]
        [TestCase(true, TestName = "Small")]
        [TestCase(false, TestName = "Big")]
        public void TestBenchmark(bool small)
        {
            var inputs = small ? inputSmall : inputBig;
            
            var result = new List<(string Name, long Milliseconds)>();
            
            var sw = new Stopwatch();
            
            sw.Restart();
            parallelCalculator.SumMono(inputs);
            sw.Stop();
            
            result.Add(("Mono", sw.ElapsedMilliseconds));
            
            sw.Restart();
            parallelCalculator.SumMonoLinq(inputs);
            sw.Stop();
            
            result.Add(("MonoLinq", sw.ElapsedMilliseconds));
            
            sw.Restart();
            parallelCalculator.SumParallelPLinq(inputs);
            sw.Stop();
            
            result.Add(("ParallelPLinq", sw.ElapsedMilliseconds));
            
            sw.Restart();
            parallelCalculator.SumParallelTaskWhenAll(inputs);
            sw.Stop();
            
            result.Add(("TaskWhenAll", sw.ElapsedMilliseconds));
            
            sw.Restart();
            parallelCalculator.SumParallel3(inputs);
            sw.Stop();
            
            result.Add(("Parallel3", sw.ElapsedMilliseconds));

            var report = string.Join("\r\n", result.Select(x => $"{x.Name}: {x.Milliseconds}ms"));
            Console.WriteLine(report);
            TestContext.WriteLine(report);
            report.Should().BeEmpty();
        }

        private static IEnumerable<TestCaseData> GetTestCases()
        {
            yield return new TestCaseData(new Func<IParallelCalculator, int[], int>((calculator, inputs) => calculator.SumMono(inputs))).SetName("Sum Mono");
            yield return new TestCaseData(new Func<IParallelCalculator, int[], int>((calculator, inputs) => calculator.SumMonoLinq(inputs))).SetName("Sum Mono Linq");
            yield return new TestCaseData(new Func<IParallelCalculator, int[], int>((calculator, inputs) => calculator.SumParallelPLinq(inputs))).SetName("Sum Parallel PLinq");
            yield return new TestCaseData(new Func<IParallelCalculator, int[], int>((calculator, inputs) => calculator.SumParallelTaskWhenAll(inputs))).SetName("Sum Parallel TaskWhenAll");
            yield return new TestCaseData(new Func<IParallelCalculator, int[], int>((calculator, inputs) => calculator.SumParallel3(inputs))).SetName("Sum Parallel 3");
        }
    }
}