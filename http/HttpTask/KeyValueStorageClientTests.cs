using System;
using System.IO;
using System.Net;
using FluentAssertions;
using NUnit.Framework;

namespace EncapsulationTask
{
    public class KeyValueStorageClientTests : TestBase
    {
        protected IKeyValueStorageClient client;

        protected override void Setup()
        {
            client = new KeyValueStorageClient();
        }

        [Test]
        public void TestPing()
        {
            client.Ping().Should().BeTrue();
        }

        [Test]
        public void TestFindRandom()
        {
            var key = Guid.NewGuid().ToString();
            client.Find(key).Should().BeNull();
        }

        [Test]
        public void TestCreate()
        {
            var kv = new KeyValue
            {
                Key = Guid.NewGuid().ToString(),
                Value = Guid.NewGuid().ToString()
            };

            client.Create(kv);

            client.Find(kv.Key).Should().BeEquivalentTo(kv);
        }

        [Test]
        public void TestUpdate()
        {
            var kv = new KeyValue
            {
                Key = Guid.NewGuid().ToString(),
                Value = Guid.NewGuid().ToString()
            };

            client.Create(kv);

            client.Find(kv.Key).Should().BeEquivalentTo(kv);

            var newValue = Guid.NewGuid().ToString();

            client.Update(kv.Key, newValue);

            var newKv = new KeyValue
            {
                Key = kv.Key,
                Value = newValue
            };

            client.Find(kv.Key).Should().BeEquivalentTo(newKv);
        }

        [Test]
        public void TestSelectAllRandom()
        {
            var key = Guid.NewGuid().ToString();
            client.Select(key).Should().BeEmpty();
        }

        [Test]
        public void TestSelectAll()
        {
            var kv1 = new KeyValue
            {
                Key = Guid.NewGuid().ToString(),
                Value = Guid.NewGuid().ToString()
            };

            var kv2 = new KeyValue
            {
                Key = Guid.NewGuid().ToString(),
                Value = Guid.NewGuid().ToString()
            };

            client.Create(kv1);
            client.Create(kv2);

            client.Select(kv1.Key, kv2.Key).Should().BeEquivalentTo(kv1, kv2);
        }

        [Test]
        public void TestCreateAll()
        {
            var kv1 = new KeyValue
            {
                Key = Guid.NewGuid().ToString(),
                Value = Guid.NewGuid().ToString()
            };

            var kv2 = new KeyValue
            {
                Key = Guid.NewGuid().ToString(),
                Value = Guid.NewGuid().ToString()
            };

            client.CreateAll(kv1, kv2);

            client.Select(kv1.Key, kv2.Key).Should().BeEquivalentTo(kv1, kv2);
        }

        [Test]
        public void TestCreateDuplicated()
        {
            var kv = new KeyValue
            {
                Key = Guid.NewGuid().ToString(),
                Value = Guid.NewGuid().ToString()
            };

            client.Create(kv);
            var ex = Assert.Throws<Exception>(()=>client.Create(kv));
            var message = ex.Message;
            message.Should().NotBeNull();
            message.Should().Be($"Key {kv.Key} is already presented in store.");
        }

        private static string GetBody(HttpWebResponse response)
        {
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}