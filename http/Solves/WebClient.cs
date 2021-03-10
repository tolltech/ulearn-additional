using System.Linq;
using Newtonsoft.Json;

namespace Solves
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
            using (var client = new System.Net.WebClient())
            {
                var response = client.DownloadString(GetUrl(urlPart, queryParamns));
                return JsonConvert.DeserializeObject<TResult>(response);
            }
        }

        public void SendGet(string urlPart, params (string ParamName, string ParamValue)[] queryParamns)
        {
            SendGet<object>(urlPart, queryParamns);
        }

        public TResult SendPost<TBody, TResult>(string urlPart, TBody body, params (string ParamName, string ParamValue)[] queryParamns)
        {
            using (var client = new System.Net.WebClient())
            {
                var strBody = string.Empty;
                if (body != null)
                {
                    strBody = JsonConvert.SerializeObject(body);
                }

                var url = GetUrl(urlPart, queryParamns);
                var response = client.UploadString(url, strBody);
                return JsonConvert.DeserializeObject<TResult>(response);
            }
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