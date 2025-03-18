using MediatR;

namespace Application.Features.Events.Commands.Create
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        public Task Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
