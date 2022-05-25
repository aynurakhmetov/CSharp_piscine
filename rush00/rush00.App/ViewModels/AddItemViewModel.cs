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
        DateTimeOffset dateOfStart;
        double daysToChallenge = 1;
        
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
        
        public DateTimeOffset DateOfStart
        {
            get => dateOfStart;
            set => this.RaiseAndSetIfChanged(ref dateOfStart, value);
        }
        
        public double DaysToChallenge
        {
            get => daysToChallenge;
            set => this.RaiseAndSetIfChanged(ref daysToChallenge, value);
        }
        
        public ReactiveCommand<Unit, Habit> Start { get; }

        public AddItemViewModel()
        {
            DateOfStart = new DateTimeOffset(DateTime.Today);
            
            var okEnabled = this.WhenAnyValue(
                x => x.Title,
                x => !string.IsNullOrWhiteSpace(x));
            
            Console.WriteLine($"000 Title: {title}, Motiv: {motivation}, DayToCh: {daysToChallenge}");

            Start = ReactiveCommand.Create(
                () => new Habit
                {
                    Title = Title,
                    Motivation = Motivation,
                    HabitCheckList = GetHabitCheckList(),
                    IsFinished = false
                }, 
                okEnabled);
            
            Console.WriteLine($"222 Title: {title}, Motiv: {motivation}, DayToCh: {daysToChallenge}");
        }

        List<HabitCheck> GetHabitCheckList()
        {
            List<HabitCheck> HabitCheckList = new List<HabitCheck>();
            
            HabitCheckList.Add(new HabitCheck {Date = DateOfStart, IsChecked = false});
            
            for (int i = 0; i < DaysToChallenge; i++)
            {
                HabitCheckList.Add(new HabitCheck {Date = DateOfStart.AddDays(1), IsChecked = false});
            }
            Console.WriteLine($"111 Title: {title}, Motiv: {motivation}, Day: {dateOfStart}, DayToCh: {daysToChallenge}");
            return HabitCheckList;
        }
        
    }
}