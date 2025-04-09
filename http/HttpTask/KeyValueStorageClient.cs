namespace HttpTask
{
    public class KeyValueStorageClient : IKeyValueStorageClient
    {
        //попробуйте реализовать сетевое key-value хранилище 
        //хорошо, что сервер уже написан за вас!
        //более подробное описание АПИ можно найти по этому адресу https://tolltech.ru/study/help
        //если апи не работает, напишите на alexandrovpe@gmail.com
        public bool Ping()
        {
            throw new System.NotImplementedException();
        }

        public void Create(KeyValue keyValue)
        {
            throw new System.NotImplementedException();
        }

        public void Update(string key, string value)
        {
            throw new System.NotImplementedException();
        }

        public KeyValue Find(string key)
        {
            throw new System.NotImplementedException();
        }

        public KeyValue[] Select(params string[] keys)
        {
            throw new System.NotImplementedException();
        }

        public void CreateAll(params KeyValue[] keyValues)
        {
            throw new System.NotImplementedException();
        }
    }
}