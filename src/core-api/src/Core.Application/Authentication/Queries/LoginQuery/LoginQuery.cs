using Core.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Core.Application.Authentication.Queries.LoginQuery
{
    public record LoginQuery(
        string Email,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}