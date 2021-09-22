namespace d01_ex01
{
    record CreatedEvent : Event
    {
        public CreatedEvent() : base(TaskState.New)
        {
        }
    }
}