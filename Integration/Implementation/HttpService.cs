using System.Net.Http.Headers;
using System.Collections.Generic;


namespace Gadget.api.Integration.Implementation
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task <HttpResponseMessage> Get(string url, IDictionary<string, string> headers, string token, string httpClientName)
        {
            var client = _clientFactory.CreateClient(httpClientName);
            if(!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            if(headers != null)
            foreach(var tm in headers)
            {
                client.DefaultRequestHeaders.Add(tm.Key, tm.Value);
            }
            return await client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> Post(string url, HttpContent content, IDictionary<string, string> headers, string token, string httpClientName)
        {
           var client = _clientFactory.CreateClient(httpClientName);
            if(!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            if(headers != null)
            foreach(var tm in headers)
            {
                client.DefaultRequestHeaders.Add(tm.Key, tm.Value);
            }
            return await client.PostAsync(url,content);
        }

        public async Task<HttpResponseMessage> Put(string url, HttpContent content, IDictionary<string, string> headers, string token, string httpClientName)
        {
            var client = _clientFactory.CreateClient(httpClientName);
            if(!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            if(headers != null)
            foreach(var tm in headers)
            {
                client.DefaultRequestHeaders.Add(tm.Key, tm.Value);
            }
            return await client.PostAsync(url,content);
        }




        //This methode maybe needed inside class that called the instance of HttpService
        //In irder to pass all request headers with IDictionary DataType
        private IDictionary<string, string> GetKeys()
        {
            string Value = "";
            var values = new Dictionary<string, string>
            {
            //e.g
            {"api-key", Value},
            {"api-key", Value},
            {"api-key", Value}

            };
            return values;

        }
    }
}