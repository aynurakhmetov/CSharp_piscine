namespace d01_ex01
{
    record TaskDoneEvent : Event
    {
        public TaskDoneEvent() : base(TaskState.Done)
        {
        }
    }    
}