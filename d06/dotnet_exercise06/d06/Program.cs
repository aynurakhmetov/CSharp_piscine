using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using d06.Extensions;
using d06.Models;
using Microsoft.Extensions.Configuration;

namespace d06
{
    class Program
    {
        static (TimeSpan, TimeSpan) GetTimeFromJson()
        {
            var path = Directory.GetCurrentDirectory();
            var configFilePath = path + "/../../../" + "appsettings.json";
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(configFilePath).Build();

            var secondsOne = double.Parse(configuration["TimeForItemInCartInSeconds"]);
            var secondsTwo = double.Parse(configuration["TimeToSwitchBetweenCustomersInSeconds"]);

            int secondsOneInt = (int)secondsOne;
            int milliSecondsOne = (int)((secondsOne - secondsOneInt) * 1000);
            
            int secondsTwoInt = (int)secondsTwo;
            int milliSecondsTwo = (int)((secondsTwo - secondsTwoInt) * 1000);
            
            var timeForItem = new TimeSpan(0, 0, 0, secondsOneInt, milliSecondsOne);
            var timeToSwitch = new TimeSpan(0, 0, 0,secondsTwoInt, milliSecondsTwo);
            
            return (timeForItem, timeToSwitch);
        }
        
        static void Main(string[] args)
        {
            const int registerCount = 4;
            const int storageCapacity = 50;
            const int cartCapacity = 7;
            TimeSpan timeNewCustomer = new TimeSpan(0, 0, 5); 
            var time = GetTimeFromJson();
            var timeForItem = time.Item1;
            var timeToSwitch = time.Item2;
            const int customerCount = 10;
            
            var customers = Enumerable.Range(1, customerCount)
                .Select(x => new Customer(x))
                .ToArray();

            foreach (var c in customers)
            {
                c.FillCart(cartCapacity);
            }

            var shop = new Store(registerCount, storageCapacity, 
                timeForItem, timeToSwitch);
            
            Console.WriteLine("Lines by people count:");

            Parallel.ForEach(customers, customer => customer.GetInLineByPeople(shop.Registers));
            shop.OpenRegisters();
            int numOfCustomer = 11;
            while (shop.IsOpen)
            {
                var customer = new Customer(numOfCustomer++);
            
                customer.FillCart(cartCapacity);
                var register = customer.GetInLineByPeople(shop.Registers);

                Thread.Sleep(timeNewCustomer);
            }
        }
    }
}
