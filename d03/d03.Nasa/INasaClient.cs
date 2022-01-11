namespace d03.Nasa
{
    interface INasaClient<in TIn, out TOut>
    {
        TOut GetAsync(TIn input);
    }
}
