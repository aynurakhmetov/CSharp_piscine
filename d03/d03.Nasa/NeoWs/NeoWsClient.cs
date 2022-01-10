using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        private async Task<Dictionary<string, string>> GetAsteroidId(int resultCount)
        {
            var asteroidInfo = new AstInfo();
            
            var statusCode = await this.GetStatusCodeAsync(this._url);
            if (statusCode == HttpStatusCode.OK)
            {
                asteroidInfo = await this.HttpGetAsync<AstInfo>(this._url);
                Console.WriteLine($"\nI AM HERE 02 {asteroidInfo.AsteroidInfos.Count}\n");
                var id = new Dictionary<string, string>();
                foreach (var ids in asteroidInfo.AsteroidInfos)
                {
                    for (int j = 0; j < ids.Value.Length; j++)
                    {
                        id.Add(ids.Value[j].Id, ids.Value[j].CloseApproachDataList[0].MissDistance.Kilometers);
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
            Console.WriteLine($"\nfinaly count = {count}\n");
            this.asteroidLookup = new AsteroidLookup[count];

            var selectedId = from i in id.Result
                orderby double.Parse(i.Value)
                select i.Key;
            
            var selectedId2 = from i in id.Result
                orderby double.Parse(i.Value)
                select i;

            foreach (var idk in selectedId2)
            {
                Console.WriteLine($"id = {idk.Key}, kiloms = {idk.Value}");
            }
            //Полученный список сортируем по расстоянию от Земли и берем из него только необходимое нам количество элементов (ResultCount) с наименьшим расстоянием
            //Для фильтрации коллекций, выборки данных, выборки необходимого их количества не используйте циклы!
            //Вам помогут расширения LINQ: Select/SelectMany, Where, OrderBy/OrderByDescending, First/Last/Single, FirstOrDefault/LastOrDefault/SingleOrDefault, Take/Skip.

            int j = 0;
            foreach (var ids in selectedId)
            {
                var newUrl = this._urlNeoLookup + ids + "?api_key=";
                Console.WriteLine($"\nfinaly count = {count}\n");
                var statusCode = await this.GetStatusCodeAsync(newUrl);
                if (statusCode == HttpStatusCode.OK)
                {
                    asteroidLookup[j] = await this.HttpGetAsync<AsteroidLookup>(newUrl);
                }
                else
                {
                    Console.WriteLine($"GET \"{this._url}\" returned {statusCode.ToString()}:");
                    var responseBody = await this.response.Content.ReadAsStringAsync();
                    Console.WriteLine($"{responseBody}");
                    return null;
                }
                j++;
                if (j == count)
                    break;
            }
            return asteroidLookup;
        }
    }
}
