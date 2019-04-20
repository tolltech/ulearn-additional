using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Stringify.Common;

namespace Stringify
{
    public class GreatClassTests : TestBase
    {
        [TestCaseSource(nameof(GetVerifiablePart))]
        public void SerializeTest(string[] verifiableValues)
        {
            var serializedClass = CustomConvert.Serialize(greatClass);

            serializedClass.Should().ContainAll(verifiableValues);
        }

        private static IEnumerable<string[]> GetVerifiablePart()
        {
            yield return TestConstants.ConstructorsInfo;
            yield return TestConstants.PropertiesInfo;
            yield return TestConstants.FieldsInfo;
            yield return TestConstants.ClassMethodsInfo;
            yield return TestConstants.AllClassInfo;
        }
    }
}