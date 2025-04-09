using System.Net;
using Newtonsoft.Json;

namespace HttpSolves
{
    public class WebClient
    {
        private readonly string host;

        public WebClient(string host)
        {
            this.host = host;
        }

        public TResult SendGet<TResult>(string urlPart, params (string ParamName, string ParamValue)[] queryParamns)
        {
            using var client = new HttpClient();
            var response = client.GetAsync(GetUrl(urlPart, queryParamns)).GetAwaiter().GetResult();
            var responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<TResult>(responseStr);
        }

        public void SendGet(string urlPart, params (string ParamName, string ParamValue)[] queryParamns)
        {
            SendGet<object>(urlPart, queryParamns);
        }

        public TResult SendPost<TBody, TResult>(string urlPart, TBody body,
            params (string ParamName, string ParamValue)[] queryParamns)
        {
            using var client = new HttpClient();
            var strBody = string.Empty;
            if (body != null)
            {
                strBody = JsonConvert.SerializeObject(body);
            }

            var url = GetUrl(urlPart, queryParamns);
            var response = client.PostAsync(url, new StringContent(strBody)).GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(response.ReasonPhrase);
            }

            var responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<TResult>(responseStr);
        }

        public TResult SendPost<TResult>(string urlPart, params (string ParamName, string ParamValue)[] queryParamns)
        {
            return SendPost<object, TResult>(urlPart, null, queryParamns);
        }

        public void SendPost<TBody>(string urlPart, TBody body,
            params (string ParamName, string ParamValue)[] queryParamns)
        {
            SendPost<TBody, object>(urlPart, body, queryParamns);
        }

        public void SendPost(string urlPart, params (string ParamName, string ParamValue)[] queryParamns)
        {
            SendPost<object>(urlPart, null, queryParamns);
        }

        private string GetUrl(string urlPart, params (string ParamName, string ParamValue)[] queryParamns) =>
            $"{host}/{urlPart}?{string.Join("&", queryParamns.Select(x => $"{x.ParamName}={x.ParamValue}"))}";
    }
}