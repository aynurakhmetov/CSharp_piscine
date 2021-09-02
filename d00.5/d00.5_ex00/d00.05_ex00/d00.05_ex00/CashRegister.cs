using System.Collections.Generic;

namespace d00._05_ex00
{
    public class CashRegister
    {
        private string Title { get; set; }
        public Queue<Customer> customers { get; set; }

        public CashRegister(string t)
        {
            this.Title = t;
            customers = new Queue<Customer>();
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
