using Core.Application.Restaurants.Commands.CreateRestaurant;
using Core.Application.Restaurants.Commands.DeleteRestaurant;
using Core.Application.Restaurants.Common;
using Core.Application.Restaurants.Queries.GetRestaurant;
using Core.Application.Restaurants.Queries.GetRestaurants;
using Core.Contracts.Restaurant.Request;
using Core.Contracts.Restaurant.Response;
using Core.Domain.CategoryAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class RestaurantMappingConfig : IRegister
    {
        public void Register(
            TypeAdapterConfig config)
        {
            //
            // Response
            //

            // TODO: Move prefix to env
            config.NewConfig<RestaurantDTO, RestaurantResponseWithDetails>()
                .Map(dest => dest.Id, src => src.Restaurant.Id.Value)
                .Map(dest => dest.ImageUrl, src => $"http://192.168.0.5:8080/{src.Restaurant.ImageUrl}")
                .Map(dest => dest.IsActive, src => IsActive(src.Restaurant))
                .Map(dest => dest.Distance, src => src.Distance)
                .Map(dest => dest, src => src.Restaurant);

            config.NewConfig<RestaurantDTO, RestaurantResponse>()
                .Map(dest => dest.Id, src => src.Restaurant.Id.Value)
                .Map(dest => dest.ImageUrl, src => $"http://192.168.0.5:8080/{src.Restaurant.ImageUrl}")
                .Map(dest => dest.IsActive, src => IsActive(src.Restaurant))
                .Map(dest => dest.Distance, src => src.Distance)
                .Map(dest => dest, src => src.Restaurant);

            //
            // Create
            //

            config.ForType<CreateRestaurantRequest, CreateRestaurantCommand>()
                .Map(dest => dest.Categories, src => src.Categories.Adapt<List<CategoryId>>())
                .PreserveReference(true);

            //
            // Delete
            //

            config.NewConfig<Guid, DeleteRestaurantCommand>()
                .Map(dest => dest.RestaurantId, src => RestaurantId.Create(src));

            //
            // Update
            //



            //
            // Get
            //

            config.NewConfig<(Guid, GetRestaurantRequest), GetRestaurantQuery>()
                .Map(dest => dest.RestaurantId, src => RestaurantId.Create(src.Item1))
                .Map(dest => dest, src => src.Item2);

            config.NewConfig<GetRestaurantsRequest, GetRestaurantsQuery>()
                .Map(dest => dest.CategoriesIds, src => (src.Categories ?? new List<Guid>()).ConvertAll(CategoryId.Create));

            //
            // Utils
            //

            config.NewConfig<RestaurantId, RestaurantId>()
                .MapWith(src => src);
        }

        private static bool IsActive(Restaurant restaurant)
        {
            var now = DateTime.Now;
            var currentTime = TimeOnly.FromDateTime(now);

            if (restaurant.OpeningHours.OpenTime < currentTime
                && restaurant.OpeningHours.CloseTime > currentTime)
            {
                return true;
            }

            return false;
        }
    }
}