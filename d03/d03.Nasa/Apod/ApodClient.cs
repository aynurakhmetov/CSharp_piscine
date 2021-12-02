using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    public class ApodClient : ApiClientBase, INasaClient<int, Task<MediaOfToday[]>>
    {
        public int ResultCount { get; private set;}
        public MediaOfToday[] media;
        private string _url = "https://api.nasa.gov/planetary/apod?api_key=";
        public ApodClient() {}
        public ApodClient(string apiKey) : base(apiKey)
        {
        }
        
        public async Task<MediaOfToday[]> GetAsync(int resultCount)
        {
            ResultCount = resultCount;
            this.media = new MediaOfToday[ResultCount];
            for (int i = 0; i < ResultCount; i++)
            {
                media[i] = await this.HttpGetAsync<MediaOfToday>(this._url + this.apiKey);
            }
            //throw new System.NotImplementedException();
            return media;
        }

        public void DisplayMedia()
        {
            for (int i = 0; i < ResultCount; i++)
            {
                Console.WriteLine(media[i].Date.ToString("d"));
                Console.Write($"'{media[i].Title}'");
                if (media[i].Copyright != "")
                {
                    Console.WriteLine($" by {media[i].Copyright}");
                }
                else
                {
                    Console.WriteLine();
                }
                Console.WriteLine($"{media[i].Explanation}\n{media[i].Url}\n");
            }
        }
    }
}

// Свойства и поля - лучшая практика разобраться
