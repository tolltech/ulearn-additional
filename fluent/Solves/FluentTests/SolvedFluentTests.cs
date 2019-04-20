using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace FluentAssertionTask
{
    public class FluentTests
    {
        [Test]
        public void TestObjectsAreEqual()
        {
            var a = 4;
            var a1 = 4;
            var b = 2;

            a.Should().Be(a1);
            a.Should().NotBe(b);
        }

        [Test]
        public void TestObjectReferencesAreEqual()
        {
            var first = new object();
            var second = first;
            var third = new object();

            first.Should().BeSameAs(second);
            first.Should().NotBeSameAs(third);
        }

        [Test]
        public void TestBooleanObjects()
        {
            var iLoveOrangeJuice = true;
            var izhevskIsTheCapitalOfGreatBritain = false;

            iLoveOrangeJuice.Should().BeTrue();
            izhevskIsTheCapitalOfGreatBritain.Should().BeFalse();
        }

        [Test]
        public async Task TestCanWorkWithExceptions()
        {
            Action action = () => throw new NotImplementedException();
            Action emptyAction = () => { };
            async Task MethodThatThrows()
            {
                await Task.Delay(100);
                throw new NotImplementedException();
            }
            Func<Task> func = async () => await MethodThatThrows();

            action.Should().Throw<NotImplementedException>();
            emptyAction.Should().NotThrow();
            await func.Should().ThrowAsync<NotImplementedException>();
        }

        [Test]
        public void TestStringAssertions()
        {
            var myString = "myString";
            var myString1 = "MYSTRING";

            myString.Should().BeEquivalentTo(myString1);
            myString.Should().EndWith("ing");
        }

        [Test]
        public void TestDecimalAssertions()
        {
            2.Should().BeGreaterThan(1);
            42.Should().BeLessThan(43);
            0.Should().Be(0);
            10.Should().BePositive();
            13.Should().BeLessOrEqualTo(14);
        }

        [Test]
        public void TestCollectionsAssertions()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var numbers1 = new[] { 5, 1, 3, 4, 2 };
            var emptyArray = Array.Empty<int>();

            numbers.Should().NotBeNull();
            numbers.Should().NotBeEmpty();
            numbers.Should().Contain(3);

            emptyArray.Should().BeEmpty();

            numbers.Should().NotBeSameAs(numbers1);
            numbers.Should().BeInAscendingOrder();
            numbers.Should().OnlyHaveUniqueItems();
        }
    }
}