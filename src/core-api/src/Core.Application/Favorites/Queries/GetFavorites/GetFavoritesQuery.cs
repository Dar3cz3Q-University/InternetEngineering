using ErrorOr;
using MediatR;

namespace Core.Application.Favorites.Queries.GetFavorites
{
    public record GetFavoritesQuery() : IRequest<ErrorOr<List<Guid>>>;
}