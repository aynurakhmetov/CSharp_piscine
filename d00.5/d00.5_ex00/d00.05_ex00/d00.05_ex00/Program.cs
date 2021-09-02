using System.Collections.Generic;
using d00._05_ex00;

Store store = new Store(40, 30);
var customers = new List<Customer>();
customers.Add(new Customer("Aynur", 1));
customers.Add(new Customer("Aydar", 2));
customers.Add(new Customer("Ayrat", 3));
customers.Add(new Customer("Aygul", 4));
customers.Add(new Customer("Ivan", 5));
customers.Add(new Customer("Igor", 6));
customers.Add(new Customer("Ilarion", 7));
customers.Add(new Customer("Ilya", 8));
customers.Add(new Customer("Ian", 9));
customers.Add(new Customer("Kilrill", 10));

while (store.IsOpen())
{
    foreach (var customer in customers)
    {
        customer.FillCart(7);
        if (customer.NumberOfItemsInCart <= store.StorageOfStore.NumberOfItemsInStorage)
            store.StorageOfStore.NumberOfItemsInStorage -= customer.NumberOfItemsInCart;
        else
        {
        }
        customer.LeastNumOfCustomers(store._Cashregisters).customers.Enqueue(customer);
    }
}