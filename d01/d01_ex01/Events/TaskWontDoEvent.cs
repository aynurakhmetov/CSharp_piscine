using System;

namespace d01_ex01
{
    record TaskWontDoEvent : Event
    {
        public TaskWontDoEvent() : base(TaskState.Done)
        {
        }
    }   
}