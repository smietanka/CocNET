using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CocNET.Types;
using RestSharp;
using System.Collections.Specialized;

namespace CocNET.Methods
{
    public class Request
    {
        public string TOKEN;
        public Request(string token)
        {
            TOKEN = token;
        }

        public RestClient GetClient()
        {
            string apiUrl = "https://api.clashofclans.com/v1";
            RestClient result = new RestClient(apiUrl);
            return result;
        }
        public RestRequest GetRequest(string call)
        {
            RestRequest result = new RestRequest(call);
            result.AddHeader("authorization", string.Format("Bearer {0}", TOKEN));
            return result;
        }
        public string GetCall(params object[] values)
        {
            return string.Join("/", values);
        }

        public string GetResponse(string call, string query)
        {
            var client = GetClient();
            var request = GetRequest(call+query);
            var response = client.Execute(request);
            return response.Content;
        }

        public string GetResponse(string call)
        {
            var client = GetClient();
            var request = GetRequest(call);
            var response = client.Execute(request);
            return response.Content;
        }
    }
}
