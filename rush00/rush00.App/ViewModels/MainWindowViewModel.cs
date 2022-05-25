using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using ReactiveUI;
using rush00.App.Services;
using rush00.App.ViewModels;
using rush00.App.Models;

namespace rush00.App.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        string mytitle;
        
        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }
        
        public string MyTitle
        { 
            get => mytitle; 
            private set => this.RaiseAndSetIfChanged(ref mytitle, value);
        }

        public TodoListViewModel List { get; }
        
        public MainWindowViewModel(Database db)
        {
            Console.WriteLine("I am in MainWindowViewModel(db) 1");
            int i = 0;
            foreach (var item in db.GetItems())
            {
                i++;
            }
            Console.WriteLine($"i = {i}");
            if (i > 0)
            {
                Content = List = new TodoListViewModel(db.GetItems());
            }
            else
            {
                MyTitle = "Set new habit to track";
                List = new TodoListViewModel(db.GetItems());
                this.AddItem();
            }
            Console.WriteLine("I am in MainWindowViewModel(db) 2");
        }
        

        public void AddItem()
        {
            Console.WriteLine("I am in AddItem() 1");
            var vm = new AddItemViewModel();

            Observable.Merge(
                    vm.Start)
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        MyTitle = model.Title;
                        List.Items.Add(model);
                        
                        Console.WriteLine($"333 vm {vm.Title}, {vm.Motivation}, {vm.DateOfStart}, " +
                                          $"{vm.DaysToChallenge}");
                        Console.WriteLine($"333 model {model.Title}, {model.Motivation}, {model.HabitCheckList.Count}, " +
                                          $"{model.HabitCheckList[0].Date}, {model.IsFinished}");
                    }

                    Content = List;
                });

            Content = vm;
            Console.WriteLine("I am in AddItem() 2");
        }
    }
}