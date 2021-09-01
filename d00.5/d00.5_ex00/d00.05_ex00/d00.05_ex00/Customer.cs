using System;

namespace queue
{
    public class Customer
    {
        private string Name{ get; set; }
        private int OrderNumOfClient { get; set; }
        public int NumOfItemsInCart { get; private set; }

        public Customer(string n, int o)
        {
            this.Name = n;
            this.OrderNumOfClient = o;
            this.NumOfItemsInCart = 0;
        }

        public override string ToString()
        {
            return "Name = " + this.Name + ", Order number of customer = " + this.OrderNumOfClient;
        }
        
        public static bool operator==(Customer c1, Customer c2)
        {
            if (c1.Name == c2.Name && c1.OrderNumOfClient == c2.OrderNumOfClient)
                return true;
            else
                return false;
        }
        
        public static bool operator!=(Customer c1, Customer c2)
        {
            if (c1.Name == c2.Name && c1.OrderNumOfClient == c2.OrderNumOfClient)
                return false;
            else
                return true;
        }

        public void FillCart(int max)
        {
            Random rnd = new Random();
            this.NumOfItemsInCart = rnd.Next(0, max);
        }
    }
}