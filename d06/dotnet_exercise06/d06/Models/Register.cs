using System;
using System.Collections.Generic;
using System.Threading;

namespace d06.Models
{
    public class Register
    {
        public int No { get; }
        public Queue<Customer> QueuedCustomers { get; }
        public TimeSpan SecondsForItemInCart { get; }
        public TimeSpan SecondsToSwitchBetweenCustomers { get; }
        public TimeSpan TotalTimeOfWork { get; private set; }
        
        public Register(int number, TimeSpan timeForItem, TimeSpan timeTiSwitch)
        {
            No = number;
            QueuedCustomers = new Queue<Customer>();
            SecondsForItemInCart = timeForItem;
            SecondsToSwitchBetweenCustomers = timeTiSwitch;
            TotalTimeOfWork = new TimeSpan(0, 0, 0);
        }

        public void Process(Customer customer)
        {
            var totalTimeForOne = customer.ItemsInCart * SecondsForItemInCart + SecondsToSwitchBetweenCustomers;
            TotalTimeOfWork += totalTimeForOne;
            Thread.Sleep(totalTimeForOne);
        }

        public override string ToString()
            => $"Register#{No} ({QueuedCustomers.Count} customers in line)";
    }
}