using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Errors;
using Domain.Shared;
using MediatR;

namespace Application.Features.Users.Queries.Get.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;

        public LoginQueryHandler(IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
        {
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(e => e.Email == request.Email);

            if (user is null)
            {
                return Result.Failure<string>(
                    DomainErrors.User.InvalidCredentials);
            }

            //check if user exists
            //if user exits, generate token
            string token = _jwtProvider.Generate(user);
            return token;
        }
    }
}
