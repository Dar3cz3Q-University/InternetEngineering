using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Persistance
{
    public interface IRestaurantRepository
    {
        Restaurant? Get(RestaurantId id);
        List<Restaurant> GetAll();
        void Add(Restaurant restaurant);
        void Delete(RestaurantId id);
    }
}
