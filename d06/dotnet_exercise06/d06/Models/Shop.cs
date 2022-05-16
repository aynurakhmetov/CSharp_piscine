using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using d06.Extensions;

namespace d06.Models
{
    public class Store
    {
        public List<Register> Registers { get; }
        public Storage Storage { get; }
        public bool IsOpen => !Storage.IsEmpty;

        public Store(int registerCount,
            int storageCapacity, TimeSpan timeForItem, TimeSpan timeTiSwitch)
        {
            Storage = new Storage(storageCapacity);
            Registers = Enumerable.Range(1, registerCount)
                .Select(i => new Register(i, timeForItem, timeTiSwitch))
                .ToList();
        }

        public void Process(object reg)
        {
            var register = (Register)reg;
            var countOfCustomers = 0;
            while (IsOpen)
            {
                while (register.QueuedCustomers.Count > 0)
                {
                    var customer = register.QueuedCustomers.Dequeue();
                    this.Storage.ReduceItems(customer.ItemsInCart);
                    register.Process(customer);
                    countOfCustomers++;
                    Console.WriteLine($"{customer} on {register}");
                }
            }

            Console.WriteLine($"{register} closed, total time of work = {register.TotalTimeOfWork}, " +
                              $"total customers = {countOfCustomers}, " +
                              $"average time per customers {register.TotalTimeOfWork / countOfCustomers}");
        }
        
        public void OpenRegisters()
        {
            foreach (var reg in Registers)
            {
                var registerThread = new Thread(new ParameterizedThreadStart(this.Process));
                registerThread.Start(reg);
            }
        }
    }
}