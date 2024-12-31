using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Infrastructure.Persistence.Repositories.InMemory
{
    public class InMemoryRestaurantRepository : IRestaurantRepository
    {
        private static readonly List<Restaurant> _restaurants = [];

        public Restaurant? Get(RestaurantId id)
        {
            return _restaurants.Find(r => r.Id == id);
        }
        public List<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public void Add(Restaurant restaurant)
        {
            _restaurants.Add(restaurant);
        }

        public void Delete(RestaurantId id)
        {
            _restaurants.Remove(Get(id));
        }
    }
}