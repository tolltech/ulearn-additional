using FluentAssertions;
using NUnit.Framework;

namespace EncapsulationTask
{
    public class LogicStringBuilderTest : LogicStringBuilderTestBase
    {
        protected  override ILogicStringBuilder CreateStringBuilder(string str)
        {
            return new LogicStringBuilder(str);
        }

        [Test]
        public void TestSimpleIf()
        {
            var sb = CreateStringBuilder("Snape Harry");

            var actual = sb.IfEndsWith("Harry").Append(" Potter").IfStartsWith("Snape").AddToStart("Severus ").ToString();
            actual.Should().Be("Severus Snape Harry Potter");
        }

        [Test]
        public void TestIfWhenLastIsTrue()
        {
            var sb = CreateStringBuilder("Snape Ron");

            var actual = sb.IfEndsWith("Harry").IfStartsWith("Snape").Append(" Potter").AddToStart("Severus ").ToString();
            actual.Should().Be("Severus Snape Ron Potter");
        }

        [Test]
        public void TestIfWhenLastIsFalse()
        {
            var sb = CreateStringBuilder("Snape Ron");

            var actual = sb.IfStartsWith("Snape").IfEndsWith("Harry").Append(" Potter").AddToStart("Severus ").ToString();
            actual.Should().Be("Severus Snape Ron");
        }

        [Test]
        public void TestAppenFirstTwoIfFalse()
        {
            var sb = CreateStringBuilder("Harry Harry");

            var actual = sb.Append(" Ron").IfStartsWith("Snape").IfEndsWith("Harry").Append(" Potter").AddToStart("Severus ").ToString();
            actual.Should().Be("Severus Harry Harry Ron");
        }

        [Test]
        public void TestAppenFirstIfAfterAppendTrue()
        {
            var sb = CreateStringBuilder("Harry Harry");

            var actual = sb.Append(" Ron").IfStartsWith("Snape").IfEndsWith("Ron").Append(" Potter").AddToStart("Severus ").ToString();
            actual.Should().Be("Severus Harry Harry Ron Potter");
        }
    }
}