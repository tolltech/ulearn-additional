using FluentAssertions;
using NUnit.Framework;
using Task.DontChange;

namespace Task
{
    [Parallelizable(ParallelScope.None)]
    public class ZooTests : TestBase
    {
        protected IZooFactory zooFactory;

        protected override void Setup()
        {
            Tracer.Clear();
            zooFactory = new ZooFactory();
        }

        [Test]
        public void TestSpentTime()
        {
            var zoo = zooFactory.CreateZoo();
            zoo.SpendTime();

            var actualLogs = Tracer.GetLogs();
            actualLogs.Should().NotBeEmpty();
            actualLogs.Length.Should().Be(3);
            actualLogs[0].Key.Should().Be("Lazybones SpendTime 100 milliseconds and have made some Nothing");
            actualLogs[0].SpentMilliseconds.Should().BeGreaterThan(50);

            actualLogs[1].Key.Should().Be("Elephant SpendTime 100 milliseconds and have made some A lot of shit");
            actualLogs[1].SpentMilliseconds.Should().BeGreaterThan(500);

            actualLogs[2].Key.Should().Be("Monkey SpendTime 100 milliseconds and have made some Noize");
            actualLogs[2].SpentMilliseconds.Should().BeLessThan(100);
        }
    }
}