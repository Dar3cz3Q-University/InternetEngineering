using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Infrastructure.Persistence.Repositories.InMemory
{
    public class InMemoryRestaurantRepository : IRestaurantRepository
    {
        private static readonly List<Restaurant> _restaurants = [];
        public Restaurant? GetById(RestaurantId id)
        {
            return _restaurants.Find(r => r.Id == id);
        }
        public List<Restaurant> All() => _restaurants;
        public Restaurant Add(Restaurant restaurant)
        {
            _restaurants.Add(restaurant);
            return restaurant;
        }
        public Restaurant Update(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
        public void Delete(RestaurantId id)
        {
            _restaurants.Remove(GetById(id));
        }
    }
}