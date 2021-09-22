namespace d01_ex01
{
    record Event
    {
        public TaskState ActualState { get; init; }
        
        protected Event(TaskState state)
        {
            ActualState = state;
        }
    }

}