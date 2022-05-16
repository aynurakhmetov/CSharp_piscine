using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using rush00.App.Models;
using rush00.App.ViewModels;
using rush00.Data;

namespace rush00.App.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        public TodoListViewModel(IEnumerable<Habit> items)
        {
            Console.WriteLine("I am in TodoListViewModel 1");
            Items = new ObservableCollection<Habit>(items);
            Console.WriteLine("I am in TodoListViewModel 2");
        }

        public ObservableCollection<Habit> Items { get; }
    }
}