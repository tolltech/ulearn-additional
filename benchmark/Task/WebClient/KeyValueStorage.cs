using System.Threading.Tasks;

namespace Task.WebClient
{
    public class KeyValueStorage
    {
        private readonly WebClient webClient;

        public KeyValueStorage()
        {
            webClient = new WebClient("http://musync.ru/study");
        }

        public int Sleep()
        {
            return webClient.Sleep<int>("sleep", 100);
        }

        public Task<int> SleepAsync()
        {
            return webClient.SleepAsync<int>("sleep", 100);
        }
    }
}