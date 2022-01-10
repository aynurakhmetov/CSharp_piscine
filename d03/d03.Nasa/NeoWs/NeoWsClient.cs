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

        private async Task<List<string>> GetAsteroidId(int resultCount)
        {
            var asteroidInfo = new AstInfo();
            
            var statusCode = await this.GetStatusCodeAsync(this._url);
            if (statusCode == HttpStatusCode.OK)
            {
                asteroidInfo = await this.HttpGetAsync<AstInfo>(this._url);
                Console.WriteLine($"\nI AM HERE 02 {asteroidInfo.AsteroidInfos.Count}\n");
                var id = new List<string>();
                foreach (var ids in asteroidInfo.AsteroidInfos)
                {
                    for (int j = 0; j < ids.Value.Length; j++)
                    {
                        id.Add(ids.Value[j].Id);
                    }
                }
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
            if (id.Result == null)
                return null;
            int count;
            if (asteroidRequest.ResultCount > 0 && asteroidRequest.ResultCount <= id.Result.Count)
                count = asteroidRequest.ResultCount;
            else
            {
                count = id.Result.Count;
            }
            this.asteroidLookup = new AsteroidLookup[count];

            for (int i = 0; i < count; i++)
            {
                var newUrl = this._urlNeoLookup + id.Result[i] + "?api_key=";
                var statusCode = await this.GetStatusCodeAsync(newUrl);
                if (statusCode == HttpStatusCode.OK)
                {
                    asteroidLookup[i] = await this.HttpGetAsync<AsteroidLookup>(newUrl);
                }
                else
                {
                    Console.WriteLine($"GET \"{this._url}\" returned {statusCode.ToString()}:");
                    var responseBody = await this.response.Content.ReadAsStringAsync();
                    Console.WriteLine($"{responseBody}");
                    return null;
                }
                
            }
            return asteroidLookup;
        }
    }
}
