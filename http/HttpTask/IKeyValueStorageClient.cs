namespace EncapsulationTask
{
    public interface IKeyValueStorageClient
    {
        bool Ping();
        void Create(KeyValue keyValue);
        void Update(string key, string value);
        KeyValue Find(string key);
        KeyValue[] Select(params string[] keys);
        void CreateAll(params KeyValue[] keyValues);
    }
}