using Core.Domain.UserAggregate;

namespace Core.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        (string, DateTime) GenerateToken(User user);
    }
}