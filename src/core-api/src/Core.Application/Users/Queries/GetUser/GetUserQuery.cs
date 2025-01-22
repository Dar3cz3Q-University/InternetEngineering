using Core.Application.Authentication.Common;
using Core.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Users.Queries.GetUser
{
    public record GetUserQuery() : IRequest<ErrorOr<AuthenticationDTO>>;
}
