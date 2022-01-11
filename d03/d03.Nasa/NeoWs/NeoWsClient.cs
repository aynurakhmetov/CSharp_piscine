using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace d03.Nasa
{
    public class NeoWsClient: ApiClientBase, INasaClient<AsteroidRequest, Task<AsteroidLookup[]>>
    {
        private AsteroidLookup[] _asteroidLookup;
        private string _urlFeed = "https://api.nasa.gov/neo/rest/v1/feed?start_date=";
        private string _urlNeoLookup = "https://api.nasa.gov/neo/rest/v1/neo/";
        private string _endDate = "&end_date=";
        private string _api = "&api_key=";
        public NeoWsClient() {}
        public NeoWsClient(string apiKey) : base(apiKey) {}

        private async Task<Dictionary<string, string>> GetAsteroidIdAndKilometersAsync(int resultCount)
        {
            var neatEarthAsteroid = new NearEarthAsteroid();
            var statusCode = await this.GetStatusCodeAsync(this._urlFeed);
            
            if (statusCode == HttpStatusCode.OK)
            {
                neatEarthAsteroid = await this.HttpGetAsync<NearEarthAsteroid>(this._urlFeed);
                var idAndKilometers = new Dictionary<string, string>();
                
                foreach (var astInfo in neatEarthAsteroid.AsteroidInfoFromDate)
                {
                    for (int i = 0; i < astInfo.Value.Length; i++)
                    {
                        idAndKilometers.Add(astInfo.Value[i].Id, astInfo.Value[i].CloseApproachDataList[0].MissDistance.Kilometers);
                    }
                }
                return idAndKilometers;
            }
            else
            {
                await DisplayErrorMessageAsync(this._urlFeed, statusCode);
                return null;
            }
        }
        public async Task<AsteroidLookup[]> GetAsync(AsteroidRequest asteroidRequest)
        {
            this._urlFeed = this._urlFeed + asteroidRequest.StartDate + this._endDate + asteroidRequest.EndDate + this._api;
            var idAndKilometers = GetAsteroidIdAndKilometersAsync(asteroidRequest.ResultCount);
            if (idAndKilometers.Result == null)
            {
                return null;
            }

            int resultCount;
            if (asteroidRequest.ResultCount > 0 && asteroidRequest.ResultCount <= idAndKilometers.Result.Count)
            {
                resultCount = asteroidRequest.ResultCount;
            }
            else
            {
                resultCount = idAndKilometers.Result.Count;
            }
            
            this._asteroidLookup = new AsteroidLookup[resultCount];

            var selectedId = from i in idAndKilometers.Result
                orderby double.Parse(i.Value)
                select i.Key;
            
            int count = 0;
            foreach (var id in selectedId)
            {
                var urlWithAsteroidId = this._urlNeoLookup + id + "?api_key=";
                var statusCode = await this.GetStatusCodeAsync(urlWithAsteroidId);
                
                if (statusCode == HttpStatusCode.OK)
                {
                    _asteroidLookup[count] = await this.HttpGetAsync<AsteroidLookup>(urlWithAsteroidId);
                }
                else
                {
                    await DisplayErrorMessageAsync(urlWithAsteroidId, statusCode);
                    return null;
                }
                count++;
                
                if (count == resultCount)
                {
                    break;
                }
            }
            return _asteroidLookup;
        }
    }
}
