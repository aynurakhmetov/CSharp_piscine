using System;
using System.Collections.Generic;
using d00._05_ex00;

int capacityOfStorage = 40;
int numberOfCashRegisters = 3;
int maximumCapacityInCart = 7;

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

int i = 0;

while (store.IsOpen() && i < 10)
{
    customers[i].FillCart(maximumCapacityInCart);
    if (customers[i].NumberOfItemsInCart <= store.StorageOfStore.NumberOfItemsInStorage && store.StorageOfStore.NumberOfItemsInStorage > 0)
    {
        store.StorageOfStore.NumberOfItemsInStorage -= customers[i].NumberOfItemsInCart;
    }
    else
    {
        store.StorageOfStore.NumberOfItemsInStorage = 0;
    }

    tempCashRegister = customers[i].GetCashRegisterWithLeastNumberOfCustomers(store.CashRegistersList);
    tempCashRegister.CustomersQueue.Enqueue(customers[i]);
        
    Console.WriteLine(customers[i].ToString());
    Console.WriteLine("Number of items in cart: " + customers[i].NumberOfItemsInCart);
    Console.WriteLine(tempCashRegister.ToString());
    Console.WriteLine("Number of people in queue at the cashregister: " + tempCashRegister.CustomersQueue.Count);
    var allItemsOfCashRegister = 0;
    foreach (var cs in tempCashRegister.CustomersQueue)
    {
        allItemsOfCashRegister += cs.NumberOfItemsInCart;
    }
    Console.WriteLine("The number of items in the cashregister of the queue: " + allItemsOfCashRegister);
    Console.WriteLine("Number of items in storage: " + store.StorageOfStore.NumberOfItemsInStorage);
    Console.WriteLine();

    i++;
}

Console.WriteLine();
Console.WriteLine();

var store2 = new Store(capacityOfStorage, numberOfCashRegisters);
var customers2 = new List<Customer>();
var tempCashRegister2 = new CashRegister(0);

customers2.Add(new Customer("Aynur", 1));
customers2.Add(new Customer("Aydar", 2));
customers2.Add(new Customer("Ayrat", 3));
customers2.Add(new Customer("Aygul", 4));
customers2.Add(new Customer("Ivan", 5));
customers2.Add(new Customer("Igor", 6));
customers2.Add(new Customer("Ilar", 7));
customers2.Add(new Customer("Ilya", 8));
customers2.Add(new Customer("Ian", 9));
customers2.Add(new Customer("Kirill", 10));


foreach (var customer in customers2)
{
    customer.FillCart(maximumCapacityInCart);
    if (customer.NumberOfItemsInCart <= store2.StorageOfStore.NumberOfItemsInStorage && store2.StorageOfStore.NumberOfItemsInStorage > 0)
    {
        store2.StorageOfStore.NumberOfItemsInStorage -= customer.NumberOfItemsInCart;
    }
    else
    {
        store2.StorageOfStore.NumberOfItemsInStorage = 0;
    }

    tempCashRegister2 = customer.GetCashRegisterWithLeastNumOfItems(store2.CashRegistersList);
    tempCashRegister2.CustomersQueue.Enqueue(customer);
        
    Console.WriteLine(customer.ToString());
    Console.WriteLine("Number of items in cart: " + customer.NumberOfItemsInCart);
    Console.WriteLine(tempCashRegister2.ToString());
    Console.WriteLine("Number of people in queue at the cashregister: " + tempCashRegister2.CustomersQueue.Count);
    var allItemsOfCashRegister = 0;
    foreach (var cs in tempCashRegister2.CustomersQueue)
    {
        allItemsOfCashRegister += cs.NumberOfItemsInCart;
    }
    Console.WriteLine("The number of items in the cashregister of the queue: " + allItemsOfCashRegister);
    Console.WriteLine("Number of items in storage: " + store2.StorageOfStore.NumberOfItemsInStorage);
    Console.WriteLine();

    if (!store2.IsOpen())
        break;
}
