using FluentAssertions;
using Stringify.Common;

namespace Stringify
{
    public class GreatClassTests : TestBase
    {
        protected CustomConvert customConvert;

        protected override void SetUp()
        {
            base.SetUp();
            customConvert = new CustomConvert();
        }

        [TestCaseSource(nameof(GetVerifiablePart))]
        public void SerializeTest(string[] verifiableValues)
        {
            var serializedClass = customConvert.Serialize(greatClass);

            serializedClass.Should().ContainAll(verifiableValues);
        }

        protected static IEnumerable<string[]> GetVerifiablePart()
        {
            yield return TestConstants.ConstructorsInfo;
            yield return TestConstants.PropertiesInfo;
            yield return TestConstants.FieldsInfo;
            yield return TestConstants.ClassMethodsInfo;
            yield return TestConstants.AllClassInfo;
        }
    }
}