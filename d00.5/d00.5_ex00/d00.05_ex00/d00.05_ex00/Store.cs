using System.Collections.Generic;

namespace queue
{
    public class Store
    {
        private Storage _Storage { get; set; }
        private List<CashRegister> _Cashregisters { get; set; }
        
        public Store(int capacityOfStorage, int numOfCashRegisters)
        {
            _Storage = new Storage(capacityOfStorage);
            for (int i = 1; i <= numOfCashRegisters; i++)
            {
                _Cashregisters.Add(new CashRegister(i.ToString()));
            }
        }

        public bool IsOpen()
        {
            if (_Storage.NumOfGoods != 0)
                return true;
            else
                return false;
        }
    }
}