using System;
using System.Net;
using System.Threading.Tasks;

namespace d03.Nasa
{
    public class ApodClient : ApiClientBase, INasaClient<int, Task<MediaOfToday[]>>
    {
        private MediaOfToday[] _media;
        private string _url = "https://api.nasa.gov/planetary/apod?count=";
        private string _apiParameter = "&api_key=";
        
        private ApodClient() {}
        
        public ApodClient(string apiKey) : base(apiKey) {}
        
        public async Task<MediaOfToday[]> GetAsync(int resultCount)
        {
            this._media = new MediaOfToday[resultCount];
            this._url = this._url + resultCount + this._apiParameter;
            var statusCode = await this.GetStatusCodeAsync(this._url);
            
            if (statusCode == HttpStatusCode.OK)
            {
                _media = await this.HttpGetAsync<MediaOfToday[]>(this._url);
                return _media;
            }
            else
            {
                await DisplayErrorMessageAsync(this._url, statusCode);
                return null;
            }
        }
    }
}
