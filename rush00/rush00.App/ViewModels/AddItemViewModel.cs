using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using rush00.App.Models;
using rush00.App.ViewModels;
using rush00.Data;

namespace rush00.App.ViewModels
{
    class AddItemViewModel : ViewModelBase
    {
        string title;
        string motivation;
        DateTime dateOfStart;
        int daysToChallenge = 0;
        
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }
        
        public string Motivation
        {
            get => motivation;
            set => this.RaiseAndSetIfChanged(ref motivation, value);
        }
        
        public DateTime DateOfStart
        {
            get => dateOfStart;
            set => this.RaiseAndSetIfChanged(ref dateOfStart, value);
        }
        
        public int DaysToChallenge
        {
            get => daysToChallenge;
            set => this.RaiseAndSetIfChanged(ref daysToChallenge, value);
        }
        
        public ReactiveCommand<Unit, Habit> Start { get; }

        public AddItemViewModel()
        {
            var okEnabled = this.WhenAnyValue(
                x => x.Title,
                x => !string.IsNullOrWhiteSpace(x));

            List<HabitCheck> HabitCheckList = new List<HabitCheck>();
            HabitCheckList.Add(new HabitCheck {Date = DateOfStart, IsChecked = false});
            Console.WriteLine($"\nTitle:\n {Title}\nMotiv:\n{Motivation}\nDayToCh:\n{DaysToChallenge}\n");
            for (int i = 0; i < daysToChallenge; i++)
            {
                HabitCheckList.Add(new HabitCheck {Date = DateOfStart.AddDays(i), IsChecked = false});
            }

            Start = ReactiveCommand.Create(
                () => new Habit
                {
                    Title = Title,
                    Motivation = Motivation,
                    HabitCheckList = HabitCheckList,
                    IsFinished = false
                }, 
                okEnabled);
            
            Console.WriteLine($"\nTitle:\n {Title}\nMotiv:\n{Motivation}\nDayToCh:\n{DaysToChallenge}\n");
        }
    }
}