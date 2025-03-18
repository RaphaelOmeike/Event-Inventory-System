using MediatR;

namespace Application.Features.Users.Queries.Get.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            //check if user exists
            //if user exits, generate token
            //return token

            throw new NotImplementedException();
        }
    }
}
