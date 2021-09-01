using System;
using ex00;
using ex01;

var customer1 = new Customer("Anya", 1);
var customer2 = new Customer("Yan", 2);
var customer3 = new Customer("Vlad", 3);
customer1.FillCart(15);
customer2.FillCart(15);
customer3.FillCart(15);
Console.WriteLine(customer1.ToString() + ", Number of items in his cart = " + customer1.NumOfItemsInCart);
Console.WriteLine(customer2.ToString() + ", Number of items in his cart = " + customer2.NumOfItemsInCart);
Console.WriteLine(customer3.ToString() + ", Number of items in his cart = " + customer3.NumOfItemsInCart);