namespace ex00
{
    struct ExchangeRate
    {
        public string currencyFrom;
        public string currencyTo;
        public string coefficient;

        public ExchangeRate(string curFrom, string curTo, string coeff)
        {
            currencyFrom = curFrom;
            currencyTo = curTo;
            coefficient = coeff;
        }
    }
}
