namespace Gadget.api.Integration.Implementation
{
    
    public interface IHttpService
    {        
        Task <HttpResponseMessage> Post(string url, HttpContent content, IDictionary<string, string> headers, string token, string httpClientName);
        Task <HttpResponseMessage> Get(string url,IDictionary<string, string> headers, string token, string httpClientName);
        Task <HttpResponseMessage> Put(string url, HttpContent content, IDictionary<string, string> headers, string token, string httpClientName);
    }
    
}