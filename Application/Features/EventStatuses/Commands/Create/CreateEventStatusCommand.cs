using MediatR;

namespace Application.Features.EventStatuses.Commands.Create
{
    public record CreateEventStatusCommand(
        string Name, 
        string? Description) : IRequest;
}
