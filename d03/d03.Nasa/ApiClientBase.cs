using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace d03.Nasa
{
    public abstract class ApiClientBase
    {
        protected string apiKey;
        
        protected ApiClientBase() {}
        
        protected ApiClientBase(string apiKey)
        {
            this.apiKey = apiKey;
        }

        protected async Task<HttpResponseMessage> GetResponseAsync(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url + this.apiKey);
            return response;
        }
        
        protected async Task<HttpStatusCode> GetStatusCodeAsync(string url)
        {
            var response = await GetResponseAsync(url);
            return response.StatusCode;
        }
        
        protected async Task<T> HttpGetAsync<T>(string url)
        {
            var response = await GetResponseAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseBody);
        }
    }
}
