using System;
using System.Linq;
using EncapsulationTask;

namespace Solves
{
    public class SolvedKeyValueStorage : IKeyValueStorageClient
    {
        private readonly WebClient webClient;

        public SolvedKeyValueStorage()
        {
            webClient = new WebClient("http://musync.ru/study");
        }

        public bool Ping()
        {
            try
            {
                webClient.SendGet("ping");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Create(KeyValue keyValue)
        {
            webClient.SendPost("create", keyValue);
        }

        public void Update(string key, string value)
        {
            webClient.SendPost("update", ("key", key), ("value", value));
        }

        public KeyValue Find(string key)
        {
            return webClient.SendGet<KeyValue>("find", ("key", key));
        }

        public KeyValue[] Select(params string[] keys)
        {
            var queryParams = keys.Select(x => ("keys", x)).ToArray();
            return webClient.SendGet<KeyValue[]>("select", queryParams);
        }

        public void CreateAll(params KeyValue[] keyValues)
        {
            webClient.SendPost("createall", keyValues);
        }
    }
}