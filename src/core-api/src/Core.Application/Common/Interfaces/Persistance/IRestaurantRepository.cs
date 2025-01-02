using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Persistance
{
    // TODO: [Create async repository functions #27]

    public interface IRestaurantRepository
    {
        Restaurant? GetById(RestaurantId id);
        List<Restaurant> All();
        Restaurant Add(Restaurant restaurant);
        Restaurant Update(Restaurant restaurant);
        void Delete(RestaurantId id);
    }
}