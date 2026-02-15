namespace Core.Contracts.Favorite.Response
{
    public record FavoritesResponse(
        List<Guid> RestaurantIds);
}