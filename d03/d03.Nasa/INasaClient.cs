namespace d03.Nasa
{
    interface INasaClient<in TIn, out TOut>
    {
        async TOut GetAsync(TIn input);
    }
}