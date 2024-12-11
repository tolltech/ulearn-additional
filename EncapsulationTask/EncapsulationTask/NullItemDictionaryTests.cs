using FluentAssertions;
using NUnit.Framework;

namespace EncapsulationTask
{
    [TestFixture]
    public class NullItemDictionaryTests
    {
        protected IDictionary<string, string> sut;
        protected IDictionary<int, string> sutInt;

        [SetUp]
        protected virtual void Setup()
        {
            sut = new NullItemDictionary<string, string>();
            sutInt = new NullItemDictionary<int, string>();
        }

        [Test]
        public void NotExistedKeyRequestTest()
        {
            var value = sut["abc"];

            value.Should().Be(default(string));
        }


        [Test]
        public void RefreshKeyTest()
        {
            var insertedKey = "abc";
            var insertedValue = "abc1";
            sut[insertedKey] = insertedValue;

            sut[insertedKey].Should().Be(insertedValue);
            sut.Keys.Should().Contain(insertedKey);
            sut.Values.Should().Contain(insertedValue);
            sut.Single().Should().Be(new KeyValuePair<string, string>(insertedKey, insertedValue));

            var newValue = "newValue";
            sut[insertedKey] = newValue;

            sut[insertedKey].Should().Be(newValue);
        }

        [Test]
        public void RefreshKeyWithAddMethodTest()
        {
            var insertedKey = "abc";
            var insertedValue = "abc1";
            sut[insertedKey] = insertedValue;

            sut[insertedKey].Should().Be(insertedValue);

            var newValue = "newValue";
            sut.Add(insertedKey, newValue);

            sut[insertedKey].Should().Be(newValue);
        }

        [Test]
        public void RequestByDefaultValue()
        {
            sut[null].Should().Be(default(string));
        }

        [Test]
        public void PositiveTest()
        {
            var firstKey = "abc";
            var firstValue = "acb";
            sut[firstKey] = firstValue;

            sut.Remove(firstKey);

            sut.ContainsKey(firstKey).Should().BeFalse();
            sut.TryGetValue(firstKey, out _).Should().BeFalse();
        }

        [Test]
        public void RequestByDefaultValueInt()
        {
            sutInt[0].Should().Be(default(string));
            sutInt[0] = "42";
            sutInt[0].Should().Be("42");
        }
    }
}