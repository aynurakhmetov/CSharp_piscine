using System;
using System.Collections.Generic;

namespace d00._05_ex00
{
    public static class CustomerExtensions
    {
        public static CashRegister LeastNumOfCustomers(this Customer customer, List<CashRegister> cashRedisters)
        {
            int min = Int32.MaxValue;
            CashRegister crWithLeastNumOfCusts = new CashRegister("");
            
            foreach (CashRegister cr in cashRedisters)
            {
                if (cr.customers.Count < min)
                {
                    min = cr.customers.Count;
                    crWithLeastNumOfCusts = cr;
                }
            }
            
            return crWithLeastNumOfCusts;
        }
        
        public static CashRegister LeastNumOfGoods(this Customer customer, List<CashRegister> cashRedisters)
        {
            int min = Int32.MaxValue;
            int allGoodsOfCR = 0;
            CashRegister crWithLeastGoodsOfCusts = new CashRegister("");
            
            foreach (CashRegister cr in cashRedisters)
            {
                foreach (Customer cstmr in cr.customers)
                {
                    allGoodsOfCR += cstmr.NumOfItemsInCart;
                }
                if (allGoodsOfCR < min)
                {
                    min = allGoodsOfCR; 
                    crWithLeastGoodsOfCusts = cr;
                }
            }
            
            return crWithLeastGoodsOfCusts;
        }
    }
}