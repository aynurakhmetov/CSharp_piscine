using System.Collections.Generic;

namespace d00._05_ex00
{
    public class CashRegister
    {
        public int Title { get; private set; }
        public Queue<Customer> CustomersQueue { get; set; }
        
        public CashRegister(int title)
        {
            this.Title = title;
            this.CustomersQueue = new Queue<Customer>();
        }
        
        public override string ToString()
        {
            return "Title of CashRegister: " + this.Title;
        }
        
        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != this.GetType())
                return false;

            var cashRegister = (CashRegister)obj;

            return this.Title == cashRegister.Title;
        }
        
        public override int GetHashCode()
        {
            return this.Title.GetHashCode();
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
