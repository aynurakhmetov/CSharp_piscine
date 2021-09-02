using System;
using System.Collections.Generic;
using d00._05_ex00;

int capacityOfStorage = 40;
int numberOfCashRegisters = 30;
int maximumCapacity = 7;

var store = new Store(capacityOfStorage, numberOfCashRegisters);
var customers = new List<Customer>();
var tempCashRegister = new CashRegister(0);

customers.Add(new Customer("Aynur", 1));
customers.Add(new Customer("Aydar", 2));
customers.Add(new Customer("Ayrat", 3));
customers.Add(new Customer("Aygul", 4));
customers.Add(new Customer("Ivan", 5));
customers.Add(new Customer("Igor", 6));
customers.Add(new Customer("Ilar", 7));
customers.Add(new Customer("Ilya", 8));
customers.Add(new Customer("Ian", 9));
customers.Add(new Customer("Kirill", 10));

while (store.IsOpen())
{
    foreach (var customer in customers)
    {
        customer.FillCart(maximumCapacity);
        if (customer.NumberOfItemsInCart <= store.StorageOfStore.NumberOfItemsInStorage && store.StorageOfStore.NumberOfItemsInStorage > 0)
        {
            store.StorageOfStore.NumberOfItemsInStorage -= customer.NumberOfItemsInCart;
        }
        else
        {
            store.StorageOfStore.NumberOfItemsInStorage = 0;
        }

        tempCashRegister = customer.GetCashRegisterWithLeastNumberOfCustomers(store.CashRegistersList);
        tempCashRegister.CustomersQueue.Enqueue(customer);
        customer.ToString();
        Console.WriteLine("Number of items in cart: " + customer.NumberOfItemsInCart);
        tempCashRegister.ToString();
        Console.WriteLine("Number of people in queue at the cashregister: " + tempCashRegister.CustomersQueue.Count);
        var allItemsOfCashRegister = 0;
        foreach (var cs in tempCashRegister.CustomersQueue)
        {
            allItemsOfCashRegister += cs.NumberOfItemsInCart;
        }
        Console.WriteLine("The number of items in the cashregister of the queue: " + allItemsOfCashRegister);

        if (!store.IsOpen())
            break;
    }
}