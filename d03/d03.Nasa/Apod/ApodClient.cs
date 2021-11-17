namespace d03.Nasa
{
    public class ApodClient : ApiClientBase,INasaClient<int, Task<MediaOfToday[]>>
    {
        async TOut GetAsync(TIn input)
        {

        }
    }
}