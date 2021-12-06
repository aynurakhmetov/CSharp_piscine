using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    public class ApodClient : ApiClientBase, INasaClient<int, Task<MediaOfToday[]>>
    {
        public int ResultCount { get; private set;}
        public MediaOfToday[] media;
        private string _url = "https://api.nasa.gov/planetary/apod?api_key="; //?count=1
        private string _count = "&count=";
        private DateTime _endDate = System.DateTime.Today;
        private DateTime _startDate;
        public ApodClient() {}
        public ApodClient(string apiKey) : base(apiKey)
        {
        }
        
        public async Task<MediaOfToday[]> GetAsync(int resultCount)
        {
            ResultCount = resultCount;
            this.media = new MediaOfToday[ResultCount];

            this._startDate = this._endDate.AddDays(-resultCount);

            //media = await this.HttpGetAsync<MediaOfToday[]>(this._url + this.apiKey + this._count + resultCount);

            for (int i = 0; i < ResultCount; i++)
             { 
                 //media[i] = await this.HttpGetAsync<MediaOfToday>(this._url + this.apiKey);
                 
                 
                 this._startDate = this._endDate.AddDays(-1);
                 this._url = "https://api.nasa.gov/planetary/apod?start_date=" + _startDate.ToString("yyyy-MM-dd")
                             + "&end_date=" + _endDate.ToString("yyyy-MM-dd") + "&api_key=";
                 media[i] = await this.HttpGetAsync<MediaOfToday>(this._url + this.apiKey);
                 this._endDate = this._endDate.AddDays(-1);
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
