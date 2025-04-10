namespace Domain.Exceptions
{
    public class EventCapacityExceededException : DomainException
    {
        public EventCapacityExceededException(string message) : base(message)
        {
        }
    }
}
