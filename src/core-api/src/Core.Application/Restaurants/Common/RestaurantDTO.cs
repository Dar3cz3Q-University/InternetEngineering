using Core.Domain.RestaurantAggregate;

namespace Core.Application.Restaurants.Common
{
    public record RestaurantDTO(
        Restaurant Restaurant,
        double? Distance);
}