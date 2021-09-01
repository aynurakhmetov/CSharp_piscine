using System;
using System.Collections;
using System.Collections.Generic;
using ex01;

namespace ex03
{
    public class CashRegister
    {
        private string Name { get; set; }
        private string Title { get; set; }
        public Queue<Customer> customers;

        public CashRegister(string n, string t)
        {
            this.Name = n;
            this.Title = t;
        }

        public override string ToString()
        {
            return "Title = " + this.Title;
        }

        public static bool operator==(CashRegister c1, CashRegister c2)
        {
            return c1.Title == c2.Title;
        }
        
        public static bool operator!=(CashRegister c1, CashRegister c2)
        {
            return c1.Title != c2.Title;
        }
    }
}
