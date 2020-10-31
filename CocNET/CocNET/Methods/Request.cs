using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace CocNET.Methods
{
    public class Request
    {
        private string Token;

        public static RestClient Client = new RestClient("https://api.clashofclans.com/v1");
        /// <summary>
        /// Initialize your request methods
        /// </summary>
        /// <param name="token">Your token.</param>
        public Request(string token)
        {
            Token = token;
        }

        /// <summary>
        /// Get your request to execute with authorization.
        /// </summary>
        /// <param name="resource">Query part of url</param>
        /// <returns></returns>
        public RestRequest GetRequest(string resource)
        {
            RestRequest request = new RestRequest(resource, Method.GET);
            request.AddHeader("authorization", string.Format("Bearer {0}", Token));
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public T GetResponse<T>(string call, string query)
        {
            var request = GetRequest(call+query);
            var response = Client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new TokenExpiredException(response.Content); 
            }
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public T GetResponse<T>(string call)
        {
            var request = GetRequest(call);
            var response = Client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new TokenExpiredException(response.Content);
            }
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
        public string GetCall(params object[] values)
        {
            return string.Join("/", values);
        }
    }
}
