using Domain.Shared;

namespace Domain.Errors
{
    public static class DomainErrors
    {
        public static class Event
        {
            public static readonly Func<string, Error> NameAlreadyInUse = name => new(
                "Event.NameAlreadyInUse",
                $"The specified name {name} is already in use.");
            public static readonly Func<Guid, Error> NotFound = id => new(
                "Event.NotFound",
                $"The event with the identifier {id} was not found.");
        }
        public static class EventStatus
        {
            public static readonly Func<string, Error> NameAlreadyInUse = name => new(
                "EventStatus.NameAlreadyInUse",
                $"The specified name {name} is already in use.");
            public static readonly Func<Guid, Error> NotFound = id => new(
                "EventStatus.NotFound",
                $"The eventstatus with the identifier {id} was not found.");
        }

        public static class User
        {
            public static readonly Error InvalidCredentials = new(
                "User.InvalidCredentials",
                $"The user entered invalid credentials.");
            //public static readonly Func<Guid, Error> NotFound = id => new(
            //    "Event.NotFound",
            //    $"The event with the identifier {id} was not found.");
        }
    }
}
