using API.Abstractions;
using Application.Features.Events.Commands.Create;
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateEvent([FromForm]CreateEventCommand request)
        {
            var response = await _mediator.Send(request);
            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            // file repository is needed to handle profile photo and other files...
            //return CreatedAtAction(
            //    nameof("jjj"),
            //    new { id = response.Value },
            //    response.Value);
            return Ok(response.Value);

        }
    }
}
