using Core.Application.Common.Commands;
using ErrorOr;
using MediatR;

namespace Core.Application.Users.Commands.AddAddress
{
    public record AddAddressCommand(
        CreateAddressCommand Address) : IRequest<ErrorOr<Updated>>;
}