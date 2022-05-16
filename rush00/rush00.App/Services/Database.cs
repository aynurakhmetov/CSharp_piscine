using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using rush00.App.Models;
using rush00.Data;

namespace rush00.App.Services
{
    public class Database
    {
        public IEnumerable<Habit> GetItems()
        {
            Console.WriteLine("I am in GetItems() in DataBase.cs");
            IEnumerable<Habit> items =  Enumerable.Empty<Habit>();
            return items;
        }
    }
}
    