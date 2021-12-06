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
        static readonly HttpClient client = new HttpClient();
        protected ApiClientBase()
        {
        }
        protected ApiClientBase(string apiKey)
        {
            this.apiKey = apiKey;
        }
        protected async Task<T> HttpGetAsync<T>(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            //response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            try
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine(responseBody);
                    return JsonSerializer.Deserialize<T>(responseBody);
                }
                else
                {
                    Console.WriteLine($"2GET \"{url}\" returned {response.StatusCode.ToString()}:");
                    Console.WriteLine($"0:{response.ReasonPhrase}  1:{response.TrailingHeaders} 2:{response.Content.Headers}");
                    return JsonSerializer.Deserialize<T>(responseBody);
                }
            }
            catch(WebException e)
            {
                Console.WriteLine($"0GET \"{url}\" returned {response.StatusCode.ToString()}");
                Console.WriteLine(e.Status);
            }
            catch (Exception e)
            {
                Console.WriteLine($"1GET \"{url}\" returned {response.StatusCode.ToString()}");
                Console.WriteLine(e.Message);
            }
            return JsonSerializer.Deserialize<T>(responseBody);
        }
    }
}