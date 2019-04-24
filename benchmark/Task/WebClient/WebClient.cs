using Newtonsoft.Json;

namespace Task.WebClient
{
    public class WebClient
    {
        private readonly string host;

        public WebClient(string host)
        {
            this.host = host;
        }

        public TResult Sleep<TResult>(string urlPart, int queryParam = 2000)
        {
            using (var client = new System.Net.WebClient())
            {
                var response = client.DownloadString(GetUrl(urlPart, queryParam));
                return JsonConvert.DeserializeObject<TResult>(response);
            }
        }

        public async System.Threading.Tasks.Task<TResult> SleepAsync<TResult>(string urlPart, int queryParam = 2000)
        {
            using (var client = new System.Net.WebClient())
            {
                var response = await client.DownloadStringTaskAsync(GetUrl(urlPart, queryParam)).ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TResult>(response);
            }
        }

        public void SendGet(string urlPart, int queryParam = 2000)
        {
            Sleep<object>(urlPart, queryParam);
        }

        private string GetUrl(string urlPart, int queryParam) =>
            $"{host}/{urlPart}?{queryParam}";
    }
}