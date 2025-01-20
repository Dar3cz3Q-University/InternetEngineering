using Core.Domain.UserAggregate;

namespace Core.Application.Authentication.Common
{
    public record AuthenticationDTO(
        User User,
        string Token,
        DateTime TokenExpiryDate
    );
}