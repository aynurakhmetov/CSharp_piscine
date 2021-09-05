using System;
using System.Collections.Generic;
using System.Linq;

namespace d01_ex01
{
    class Task
    {
        public string Title{ get; private set; }
        public string Summary { get; private set; }
        public TaskType Type { get; private set; }
        public TaskPriority Priority { get; private set; }
        public DateTime DueDate { get; private set; }
        public List <Event> HistoryOfEvents { get; private set; }

        public Task()
        {
        }

        private void SetNewState(Event newEvent)
        {
            if (HistoryOfEvents[HistoryOfEvents.Count - 1].ActualState == TaskState.New)
            {
                HistoryOfEvents.Add(newEvent);
            }
            else
            {
                Console.WriteLine("Ошибка изменения состояния. У это задачи конечное состояние, которое не может быть изменено");
            }
        }

        public TaskState GetActualState()
        {
            return HistoryOfEvents[HistoryOfEvents.Count - 1].ActualState;
        }

        public override string ToString()
        {
            return $"{this.Title}\n[{this.Type}] [{HistoryOfEvents.Last().ActualState}]\n" +
                   $"Priority: {this.Priority}, Due till {this.DueDate}\n{this.Summary} ";
        }
    }
}