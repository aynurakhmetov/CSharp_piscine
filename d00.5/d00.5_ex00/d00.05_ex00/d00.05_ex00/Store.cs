using System.Collections.Generic;

namespace queue
{
    public class Store
    {
        public Storage StorageOfStore { get; set; }
        public List<CashRegister> _Cashregisters { get; set; }
        
        public Store(int capacityOfStorage, int numOfCashRegisters)
        {
            StorageOfStore = new Storage(capacityOfStorage);
            for (int i = 1; i <= numOfCashRegisters; i++)
            {
                _Cashregisters.Add(new CashRegister(i.ToString()));
            }
        }

        public bool IsOpen()
        {
            if (StorageOfStore.NumOfGoods != 0)
                return true;
            else
                return false;
        }
    }
}