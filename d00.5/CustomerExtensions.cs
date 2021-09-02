using System;
using System.Collections.Generic;

namespace d00._05_ex00
{
    public static class CustomerExtensions
    {
        public static CashRegister GetCashRegisterWithLeastNumberOfCustomers(this Customer customer, List<CashRegister> cashRegistersList)
        {
            var min = Int32.MaxValue;
            var tempCashRegister = new CashRegister(0);

            foreach (var cr in cashRegistersList)
            {
                if (cr.CustomersQueue.Count < min)
                {
                    min = cr.CustomersQueue.Count;
                    tempCashRegister = cr;
                }
            }

            return tempCashRegister;
        }
        
        public static CashRegister GetCashRegisterWithLeastNumOfItems(this Customer customer, List<CashRegister> cashRegistersList)
        {
            var min = Int32.MaxValue;
            var allItemsOfCashRegister = 0;
            var tempCashRegister = new CashRegister(0);
            
            foreach (var cr in cashRegistersList)
            {
                foreach (var cs in cr.CustomersQueue)
                {
                    allItemsOfCashRegister += cs.NumberOfItemsInCart;
                }
                if (allItemsOfCashRegister < min)
                {
                    min = allItemsOfCashRegister; 
                    tempCashRegister = cr;
                }
            }
            
            return tempCashRegister;
        }
    }
}

