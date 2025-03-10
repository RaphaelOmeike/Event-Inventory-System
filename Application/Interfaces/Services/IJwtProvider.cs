using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
