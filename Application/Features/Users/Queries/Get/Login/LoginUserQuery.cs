using MediatR;

namespace Application.Features.Users.Queries.Get.Login
{
    public record LoginUserQuery(string Email, string Password) : IRequest<string>;
}
