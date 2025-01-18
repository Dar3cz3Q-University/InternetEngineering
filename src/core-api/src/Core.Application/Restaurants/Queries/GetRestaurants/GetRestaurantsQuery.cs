using Core.Application.Restaurants.Common;
using Core.Domain.CategoryAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurants
{
    public record GetRestaurantsQuery(
        double? Longitude,
        double? Latitude,
        List<CategoryId> CategoriesIds) : IRequest<ErrorOr<List<RestaurantDTO>>>;
}