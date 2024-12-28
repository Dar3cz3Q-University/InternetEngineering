using Core.Application.Authentication.Common;
using Core.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Password,
        UserRole UserRole
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}