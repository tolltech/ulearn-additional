using System;
using Documentation.Common;
using Documentation.Descriptior;
using FluentAssertions;
using NUnit.Framework;

namespace Documentation
{
    public class DescriptorTests : TestBase
    {
        private const string authorizeMethodName = "Authorize";
        private const string selectAudioMethodName = "SelectAudio";
        private const string countAudioMethodName = "GetTotalAudioCount";

        [Test]
        public void GetApiMethodNamesWithDescription()
        {
            var actuals = descriptor.GetApiMethodNames();
            actuals.Should().BeEquivalentTo(new[] {authorizeMethodName, selectAudioMethodName, countAudioMethodName});
        }

        [Test]
        public void GetApiDescription()
        {
            var description = descriptor.GetApiDescription();
            description.Should().Be("Vk API client");
        }

        [Test]
        public void GetApiMethodDescriptionRandomName()
        {
            var description = descriptor.GetApiMethodDescription(Guid.NewGuid().ToString());
            description.Should().BeNull();
        }

        [Test]
        public void GetApiMethodDescription()
        {
            var description = descriptor.GetApiMethodDescription(authorizeMethodName);
            description.Should().Be("Authorize user. Returns true if authorized");
        }

        [Test]
        public void GetApiMethodParamNames()
        {
            var description = descriptor.GetApiMethodParamNames(authorizeMethodName);
            description.Should().BeEquivalentTo("login", "password", "allowNoname");
        }

        [Test]
        public void GetApiMethodParamDescriptionWithoutDescription()
        {
            var description = descriptor.GetApiMethodParamDescription(authorizeMethodName, "allowNoname");
            description.Should().BeNull();
        }

        [Test]
        public void GetApiMethodParamDescription()
        {
            var description = descriptor.GetApiMethodParamDescription(selectAudioMethodName, "batchSize");
            description.Should().Be("number of audios to return");
        }

        [Test]
        public void GetApiMethodParamFullDescriptionRandomName()
        {
            var paramName = Guid.NewGuid().ToString();
            var description = descriptor.GetApiMethodParamFullDescription(authorizeMethodName, paramName);
            description.Should().NotBeNull();
            description.MinValue.Should().BeNull();
            description.MaxValue.Should().BeNull();
            description.Required.Should().Be(false);
            description.ParamDescription.Should().BeEquivalentTo(new CommonDescription(paramName));
        }

        [Test]
        public void GetApiMethodParamFullDescriptionNotAllAttributes()
        {
            var description = descriptor.GetApiMethodParamFullDescription(authorizeMethodName, "login");
            description.Should().NotBeNull();
            description.MinValue.Should().BeNull();
            description.MaxValue.Should().BeNull();
            description.Required.Should().Be(true);
            description.ParamDescription.Should().BeEquivalentTo(new CommonDescription("login"));
        }

        [Test]
        public void GetApiMethodParamFullDescription()
        {
            var description = descriptor.GetApiMethodParamFullDescription(selectAudioMethodName, "batchSize");
            description.Should().NotBeNull();
            description.MinValue.Should().Be(1);
            description.MaxValue.Should().Be(100);
            description.Required.Should().Be(true);
            description.ParamDescription.Should()
                .BeEquivalentTo(new CommonDescription("batchSize", "number of audios to return"));
        }

        [Test]
        public void GetFullApiMethodDescriptionAuthorizeRandomName()
        {
            var description = descriptor.GetFullApiMethodDescription("Authorize2");
            description.Should().BeNull();
        }

        [Test]
        public void GetFullApiMethodDescriptionAuthorize()
        {
            var description = descriptor.GetFullApiMethodDescription(authorizeMethodName);
            description.Should().NotBeNull();
            description.Should().BeEquivalentTo(new ApiMethodDescription
            {
                MethodDescription = new CommonDescription(authorizeMethodName,
                    "Authorize user. Returns true if authorized"),
                ParamDescriptions = new[]
                {
                    new ApiParamDescription
                    {
                        ParamDescription = new CommonDescription("login"),
                        Required = true
                    },
                    new ApiParamDescription
                    {
                        ParamDescription = new CommonDescription("password"),
                        Required = true
                    },
                    new ApiParamDescription
                    {
                        ParamDescription = new CommonDescription("allowNoname"),
                    },
                }
            });
        }

        [Test]
        public void GetFullApiMethodDescriptionSelectAudio()
        {
            var description = descriptor.GetFullApiMethodDescription(selectAudioMethodName);
            description.Should().NotBeNull();
            description.Should().BeEquivalentTo(new ApiMethodDescription
            {
                MethodDescription = new CommonDescription(selectAudioMethodName,
                    "Gets user audio tracks. If userId is not presented gets authorized user audio tracks"),
                ParamDescriptions = new[]
                {
                    new ApiParamDescription
                    {
                        ParamDescription = new CommonDescription("userId"),
                    },
                    new ApiParamDescription
                    {
                        ParamDescription = new CommonDescription("batchSize", "number of audios to return"),
                        Required = true,
                        MinValue = 1,
                        MaxValue = 100
                    },
                },
                ReturnDescription = new ApiParamDescription
                {
                    ParamDescription = new CommonDescription()
                }
            });
        }

        [Test]
        public void GetFullApiMethodDescriptionCountAudio()
        {
            var description = descriptor.GetFullApiMethodDescription(countAudioMethodName);
            description.Should().NotBeNull();
            description.Should().BeEquivalentTo(new ApiMethodDescription
            {
                MethodDescription = new CommonDescription(countAudioMethodName,
                    "Gets user audio tracks count. If userId is not presented gets authorized user audio tracks"),
                ParamDescriptions = new[]
                {
                    new ApiParamDescription
                    {
                        ParamDescription = new CommonDescription("userId"),
                    },
                },
                ReturnDescription = new ApiParamDescription
                {
                    Required = true,
                    ParamDescription = new CommonDescription(),
                    MinValue = 0,
                    MaxValue = int.MaxValue / 2
                }
            });
        }
    }
}