using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Infrastructure.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public string SecretKey { get; init; } = string.Empty;
    }
}
