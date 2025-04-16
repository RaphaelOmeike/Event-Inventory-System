using API.Abstractions;
using API.Contracts;
using Application.Features.Users.Queries.Get.Login;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator) { }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
        {
            var command = new LoginQuery(request.Email, request.Password);
            Result<string> tokenResult = await Mediator.Send(command);

            if (tokenResult.IsFailure)
            {
                return HandleFailure(tokenResult);
            }
            return Ok(tokenResult.Value);
        }
    }
}
