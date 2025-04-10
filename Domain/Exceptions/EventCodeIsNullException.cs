namespace Domain.Exceptions
{
    public class EventCodeIsNullException : DomainException
    {
        public EventCodeIsNullException(string message) : base(message)
        {
        }
    }
}
