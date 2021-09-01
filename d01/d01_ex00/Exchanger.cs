using System;
using System.Collections.Generic;

namespace ex00
{
    class Exchanger
    {
        private ExchangeSum _exSum;
        private List<ExchangeRate> _exRate;

        public Exchanger(ExchangeSum exSum, List<ExchangeRate> exRate)
        {
            this._exSum = exSum;
            this._exRate = exRate;
        }

        public decimal ToConvertCurrency(string identifer)
        {
            decimal sum;
            decimal coefficient;
            Char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
  

            for (int i = 0; i < 6; i++)
            {
                if (this._exRate[i].currencyFrom == this._exSum.currencyIdentifier && this._exRate[i].currencyTo == identifer)
                {
                    //Console.WriteLine("SUM = {0}, COEF = {1}", this._exSum.sum, this._exRate[i].coefficient);
                    decimal.TryParse(this._exSum.sum.Replace( ',' , separator), out sum);
                    decimal.TryParse(this._exRate[i].coefficient.Replace( ',' , separator), out coefficient);
                    //Console.WriteLine("SUM = {0}, COEF = {1}", sum, coefficient);
                    return sum * coefficient;
                }
            }
            return 0;
        }
    };
}
