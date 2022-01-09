using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    public class NeoWsClient: ApiClientBase, INasaClient<AsteroidRequest, Task<AsteroidLookup[]>>
    {
        public AsteroidLookup[] asteroidLookup;
        private AsteroidRequest _asteroidRequest;
        private string _url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=";
        private string _urlNeoLookup = "https://api.nasa.gov/neo/rest/v1/neo/";
        private string _endDate = "&end_date=";
        private string _api = "&api_key=";
        public NeoWsClient() {}
        public NeoWsClient(string apiKey) : base(apiKey) {}

        private async Task<List<int>> GetAsteroidId(int resultCount)
        {
            Console.WriteLine("\nI AM HERE 0\n");
            Dictionary<String, AsteroidInfo> asteroidInfo;
            
            var statusCode = await this.GetStatusCodeAsync(this._url);
            if (statusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("\nI AM HERE 01\n");
                asteroidInfo = await this.HttpGetAsync<Dictionary <String, AsteroidInfo> >(this._url);
                Console.WriteLine($"\nI AM HERE 02 {asteroidInfo.Count}\n");
                var id = new List<int>();
                // int i = 0;
                // while (i < resultCount && i < asteroidInfo.NearEarthObjects.AsteroidInfoList.Count)
                // {
                //     id.Add(asteroidInfo.NearEarthObjects.AsteroidInfoList[i].Id);
                //     i++;
                // }
                return id;
            }
            else
            {
                Console.WriteLine($"GET \"{this._url}\" returned {statusCode.ToString()}:");
                var responseBody = await this.response.Content.ReadAsStringAsync();
                Console.WriteLine($"{responseBody}");
                return null;
            }
        }
        public async Task<AsteroidLookup[]> GetAsync(AsteroidRequest asteroidRequest)
        {
            this._asteroidRequest = asteroidRequest;
            this._url = this._url + asteroidRequest.StartDate + this._endDate + asteroidRequest.EndDate + this._api;
            Console.WriteLine($"\nresCount = {asteroidRequest.ResultCount}\n");
            var id = GetAsteroidId(asteroidRequest.ResultCount);
            this.asteroidLookup = new AsteroidLookup[id.Result.Count];

            var newUrl = this._urlNeoLookup + id.Result[0] + "?api_key=";
            var statusCode = await this.GetStatusCodeAsync(newUrl);
            if (statusCode == HttpStatusCode.OK)
            {
                asteroidLookup = await this.HttpGetAsync<AsteroidLookup[]>(newUrl);
                return asteroidLookup;
            }
            else
            {
                Console.WriteLine($"GET \"{this._url}\" returned {statusCode.ToString()}:");
                var responseBody = await this.response.Content.ReadAsStringAsync();
                Console.WriteLine($"{responseBody}");
                return null;
            }
        }
    }
}
