using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    // Модификатор доступа для класса?
    public abstract class ApiClientBase
    {
        protected string apiKey;
        protected HttpClient client;
        protected HttpResponseMessage response;

        protected ApiClientBase() {}
        protected ApiClientBase(string apiKey)
        {
            this.apiKey = apiKey;
            this.client = new HttpClient();
            
        }

        protected async Task<HttpStatusCode> GetStatusCodeAsync(string url)
        {
            this.response = await client.GetAsync(url + this.apiKey);
            return response.StatusCode;
        }
        protected async Task<T> HttpGetAsync<T>(string url)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseBody);
        }
    }
}
