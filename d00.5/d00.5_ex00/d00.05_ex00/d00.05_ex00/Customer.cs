using System;

namespace d00._05_ex00
{
    public class Customer
    {
        public string Name { get; private set; }
        public int OrderNumberOfCustomer { get; private set; }
        public int NumberOfItemsInCart { get; private set; }

        public Customer(string name, int orderNumberOfCustomer)
        {
            this.Name = name;
            this.OrderNumberOfCustomer = orderNumberOfCustomer;
            this.NumberOfItemsInCart = 0;
        }

        public override string ToString()
        {
            return "Name of customer: " + this.Name + ", Order number of customer = " + this.OrderNumberOfCustomer;
        }
        
        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != this.GetType())
                return false;

            Customer cstmr = (Castomer)obj;

            return this.Name == cstmr.Name && this.OrderNumberOfCustomer == cstmr.OrderNumberOfCustomer;
        }

        public override int GetHashCode()
        {
            return this.OrderNumberOfCustomer;
        }
        public static bool operator==(Customer c1, Customer c2)
        {
            return c1.Name == c2.Name && c1.OrderNumberOfCustomer == c2.OrderNumberOfCustomer;
        }
        
        public static bool operator!=(Customer c1, Customer c2)
        {
            return c1.Name != c2.Name || c1.OrderNumberOfCustomer != c2.OrderNumberOfCustomer;
        }

        public void FillCart(int maximumCapacity)
        {
            var rnd = new Random();
            this.NumberOfItemsInCart = rnd.Next(0, maximumCapacity);
        }
    }
}
