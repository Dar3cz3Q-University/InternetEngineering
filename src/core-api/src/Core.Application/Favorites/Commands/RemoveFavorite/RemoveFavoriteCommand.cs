using ErrorOr;
using MediatR;

namespace Core.Application.Favorites.Commands.RemoveFavorite
{
    public record RemoveFavoriteCommand(
        Guid RestaurantId) : IRequest<ErrorOr<Deleted>>;
}