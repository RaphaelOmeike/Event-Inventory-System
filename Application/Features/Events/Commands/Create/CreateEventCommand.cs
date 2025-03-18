using MediatR;

namespace Application.Features.Events.Commands.Create
{
    public record CreateEventCommand(string Name) : IRequest;
}
