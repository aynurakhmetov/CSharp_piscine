using System;
using queue;

var customer1 = new Customer("Anya", 1);
var customer2 = new Customer("Yan", 2);
var customer3 = new Customer("Vlad", 3);
customer1.FillCart(15);
customer2.FillCart(15);
customer3.FillCart(15);
Console.WriteLine(customer1.ToString() + ", Number of items in his cart = " + customer1.NumOfItemsInCart);
Console.WriteLine(customer2.ToString() + ", Number of items in his cart = " + customer2.NumOfItemsInCart);
Console.WriteLine(customer3.ToString() + ", Number of items in his cart = " + customer3.NumOfItemsInCart);
var cushreg1 = new CashRegister("title1");
var cushreg2 = new CashRegister("title1");
var cushreg3 = new CashRegister("title2");
Console.WriteLine(cushreg1 == cushreg2);
Console.WriteLine(cushreg1 == cushreg3);
Console.WriteLine(cushreg1 != cushreg2);
Console.WriteLine(cushreg1 != cushreg3);