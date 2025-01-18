using ErrorOr;
using MediatR;

namespace Core.Application.Users.Commands.UpdateMaxSearchDistance
{
    public record UpdateMaxSearchDistanceCommand(
        double MaxSearchDistance) : IRequest<ErrorOr<Updated>>;
}
