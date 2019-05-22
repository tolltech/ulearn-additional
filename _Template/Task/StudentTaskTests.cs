using FluentAssertions;
using NUnit.Framework;

namespace Tasks
{
    public class StudentTaskTests : TestBase
    {
        protected ITask task;

        protected override void Setup()
        {
            task = new StudentTask();
        }

        [Test]
        public void TestPing()
        {
            task.Method().Should().BeTrue();
        }       
    }
}