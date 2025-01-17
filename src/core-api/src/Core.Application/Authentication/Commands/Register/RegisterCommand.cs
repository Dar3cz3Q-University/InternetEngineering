using Core.Application.Authentication.Common;
using Core.Application.Common.Commands;
using Core.Domain.UserAggregate;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Password,
        UserRole UserRole,
        IFormFile AvatarImage,
        CreateAddressCommand Address,
        double MaxSearchDistance) : IRequest<ErrorOr<AuthenticationDTO>>;
}