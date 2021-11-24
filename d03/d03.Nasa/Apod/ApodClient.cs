using System.Dynamic;
using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    public class ApodClient : ApiClientBase, INasaClient<int, Task<MediaOfToday[]>>
    {
        public int ResultCount { get; private set;}
        private string _url = "https://api.nasa.gov/planetary/apod?api_key=";
        private ApodClient(string apiKey) : base(apiKey)
        {
        }
        
        public Task<MediaOfToday[]> GetAsync(int input)
        {
            ResultCount = input;
            var media = new MediaOfToday[ResultCount];
            for (int i = 0; i < ResultCount; i++)
            {
                media[i] = this.HttpGetAsync<MediaOfToday>(this._url + this.apiKey).Result;
            }
            //throw new System.NotImplementedException();
            return media;
        }
    }
}

// Свойства - лучшая практика
