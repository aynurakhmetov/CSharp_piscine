using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    public class ApodClient : ApiClientBase, INasaClient<int, Task<MediaOfToday[]>>
    {
        public MediaOfToday[] media;
        private string _url = "https://api.nasa.gov/planetary/apod?count=";
        private string _api = "&api_key=";
        public ApodClient() {}
        public ApodClient(string apiKey) : base(apiKey) {}
        public async Task<MediaOfToday[]> GetAsync(int resultCount)
        {
            this.media = new MediaOfToday[resultCount];
            this._url = this._url + resultCount + this._api;
            var statusCode = await this.GetStatusCodeAsync(this._url);
            if (statusCode == HttpStatusCode.OK)
            {
                media = await this.HttpGetAsync<MediaOfToday[]>(this._url);
            }
            else
            {
                Console.WriteLine($"GET \"{this._url}\" returned {statusCode.ToString()}:");
                var responseBody = await this.response.Content.ReadAsStringAsync();
                Console.WriteLine($"{responseBody}");
            }
            return null;
        }
    }
}

// Свойства и поля - лучшая практика разобраться
