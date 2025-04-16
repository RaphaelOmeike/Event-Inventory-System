using Domain.Shared;
using MediatR;

namespace Application.Features.Users.Queries.Get.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<Result<string>>;
}
