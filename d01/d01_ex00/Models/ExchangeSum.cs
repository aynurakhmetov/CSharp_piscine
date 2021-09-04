using System.Collections.Generic;

namespace ex00
{
    struct ExchangeSum
    {
        public string sum;
        public string currencyIdentifier;
        
        public ExchangeSum(string sum, string identifer)
        {
            this.sum = sum;
            this.currencyIdentifier = identifer;
        }
        
        public ExchangeSum(string sumPlusIdentifer)
        {
            List<string> sumIdenList = new List<string>();
            for (int i = 0; i < 2; i++)
                sumIdenList.Add(sumPlusIdentifer.Split(" ")[i]);
            this.sum = sumIdenList[0];
            this.currencyIdentifier = sumIdenList[1];
        }
    }
}