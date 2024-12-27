using Core.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Core.Application.Authentication.Commands.RegisterCommand
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}