using ErrorOr;
using MediatR;

namespace Core.Application.Favorites.Commands.AddFavorite
{
    public record AddFavoriteCommand(
        Guid RestaurantId) : IRequest<ErrorOr<Created>>;
}
