using FluentAssertions;
using NUnit.Framework;
using Task.DontChange;

namespace Task
{
    [Parallelizable(ParallelScope.None)]
    public class StudentTaskTests : TestBase
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
            actualLogs.Length.Should().Be(1);
            actualLogs[0].Key.Should().Be("Lazybones SpendTime 100 milliseconds");
            actualLogs[0].SpentMilliseconds.Should().BeGreaterThan(50);
        }
    }
}