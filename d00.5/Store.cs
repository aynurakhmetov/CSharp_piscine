using System.Collections.Generic;

namespace d00._05_ex00
{
    public class Store
    {
        public Storage StorageOfStore { get; private set; }
        public List<CashRegister> CashRegistersList { get; private set; }
        
        public Store(int capacityOfStorage, int numberOfCashRegisters)
        {
            StorageOfStore = new Storage(capacityOfStorage);
            CashRegistersList = new List<CashRegister>();
            for (int i = 1; i <= numberOfCashRegisters; i++)
            {
                CashRegistersList.Add(new CashRegister(i));
            }
        }

        public bool IsOpen() => !StorageOfStore.IsEmpty();
    }
}
