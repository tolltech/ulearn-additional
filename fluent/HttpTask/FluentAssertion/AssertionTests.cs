using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FluentAssertionTask
{
    public class AssertionTests
    {
        /// <summary>
        /// http://nunit.org/docs/2.2.7/assertions.html
        /// </summary>

        [Test]
        public void TestObjectsAreEqual()
        {
            var a = 4;
            var a1 = 4;
            var b = 2;

            Assert.AreEqual(a, a1);
            Assert.AreNotEqual(a, b);
        }

        [Test]
        public void TestObjectReferencesAreEqual()
        {
            var first = new object();
            var second = first;
            var third = new object();

            Assert.AreSame(first, second);
            Assert.AreNotSame(first, third);
        }

        [Test]
        public void TestBooleanObjects()
        {
            var iLoveOrangeJuice = true;
            var izhevskIsTheCapitalOfGreatBritain = false;

            Assert.True(iLoveOrangeJuice);
            Assert.False(izhevskIsTheCapitalOfGreatBritain);
        }

        [Test]
        public void TestCanWorkWithExceptions()
        {
            async Task MethodThatThrows()
            {
                await Task.Delay(100);
                throw new NotImplementedException();
            }

            Assert.Throws<NotImplementedException>(() => throw new NotImplementedException());
            Assert.DoesNotThrow(() => { });
            Assert.ThrowsAsync<NotImplementedException>(async () => await MethodThatThrows());
        }

        [Test]
        public void TestStringAssertions()
        {
            var myString = "myString";
            var myString1 = "MYSTRING";

            StringAssert.AreEqualIgnoringCase(myString, myString1);
            StringAssert.EndsWith("ing", myString);
        }

        [Test]
        public void TestDecimalAssertions()
        {
            Assert.Greater(2, 1);
            Assert.Less(42, 43);
            Assert.Zero(0);
            Assert.Positive(10);
            Assert.LessOrEqual(13, 14);
        }

        [Test]
        public void TestCollectionsAssertions()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var numbers1 = new[] { 5, 1, 3, 4, 2 };
            var emptyArray = Array.Empty<int>();

            Assert.IsNotNull(numbers);
            Assert.IsNotEmpty(numbers);
            Assert.Contains(3, numbers);
            Assert.IsEmpty(emptyArray);

            CollectionAssert.AreNotEqual(numbers, numbers1);
            CollectionAssert.IsOrdered(numbers);
            CollectionAssert.AllItemsAreUnique(numbers);
        }
    }
}