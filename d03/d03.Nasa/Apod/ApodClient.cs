using System.Threading.Tasks;

namespace d03.Nasa.Lib
{
    public class ApodClient : ApiClientBase, INasaClient<int, Task<MediaOfToday[]>>
    {
        private ApodClient(string apiKey) : base(apiKey)
        {
        }
        
        public Task<MediaOfToday[]> GetAsync(int input)
        {
            var media = new MediaOfToday[input];
            for (int i = 0; i < input; i++)
            {
                //media[0].сopyright = HttpGetAsync<>("https://api.nasa.gov/planetary/apod?api_key=apiKey&couny=5");
            }
            throw new System.NotImplementedException(); 
        }
    }
}