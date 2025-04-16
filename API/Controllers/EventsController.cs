using API.Abstractions;
using Application.Features.Events.Commands.Create;
using Application.Features.Events.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ApiController
    {
        public EventsController(IMediator mediator) : base(mediator) { }
        [HttpPost("create")]
        public async Task<IActionResult> CreateEvent([FromForm]CreateEventCommand request)
        {
            var response = await Mediator.Send(request);
            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            // file repository is needed to handle profile photo and other files...
            return CreatedAtAction(
                nameof(GetEventById),
                new { id = response.Value },
                response.Value);
            //return Ok(response.Value);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById([FromRoute] Guid id)
        {
            var request = new GetEventByIdQuery(id);
            var response = await Mediator.Send(request);
            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            // file repository is needed to handle profile photo and other files...
            return Ok(response.Value);
        }
    }
}
