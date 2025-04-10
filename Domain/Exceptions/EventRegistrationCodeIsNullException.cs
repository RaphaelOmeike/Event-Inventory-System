namespace Domain.Exceptions
{
    public class EventRegistrationCodeIsNullException : DomainException
    {
        public EventRegistrationCodeIsNullException(string message) : base(message)
        {
        }
    }
}
