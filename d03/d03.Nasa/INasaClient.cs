namespace d03.Nasa.Lib
{
    interface INasaClient<in TIn, out TOut>
    {
        TOut GetAsync(TIn input);
    }
}
