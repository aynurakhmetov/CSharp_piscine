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
        public List<Task> tasks;

        public Task()
        {
            this.Title = null;
            this.Summary = null;
            this.Type = 0;
            this.Priority = TaskPriority.Normal;
            this.DueDate = DateTime.MinValue;
            this.HistoryOfEvents = new List<Event>();
        }

        private int SetNewState(Event newEvent)
        {
            if (newEvent.ActualState == TaskState.New)
            {
                HistoryOfEvents.Add(newEvent);
                return 1;
            }
            else if (HistoryOfEvents.Last().ActualState == TaskState.New)
            {
                HistoryOfEvents.Add(newEvent);
                return 2;
            }
            else
            {
                Console.WriteLine("Ошибка изменения состояния. У это задачи конечное состояние, которое не может быть изменено");
                return 0;
            }
        }

        public TaskState GetActualState()
        {
            return HistoryOfEvents.Last().ActualState;
        }

        public override string ToString()
        {
            string answer;
            answer = $"{this.Title}\n[{this.Type.ToString("g")}] [{HistoryOfEvents.Last().ActualState}]\n" +
                     $"Priority: {this.Priority.ToString("g")}";
            if (this.DueDate != DateTime.MinValue)
                answer += $", Due till {this.DueDate}\n";
            if (this.Summary != null)
                answer += $"{this.Summary}";
            return answer;
        }

        public int CreateNewTask(string title, string summury, DateTime duedate, TaskType type, TaskPriority priority)
        {
            this.Title = title;
            this.Summary = summury;
            this.DueDate = duedate;
            this.Type = type;
            this.Priority = priority;
            this.HistoryOfEvents = new List<Event>();
            
            return (this.SetNewState(new CreatedEvent()));
        }

        public int TaskDone()
        {
            return(this.SetNewState(new TaskDoneEvent()));
        }
        
        public int TaskWontDo()
        {
            return(this.SetNewState(new TaskWontDoEvent()));
        }
    }
}