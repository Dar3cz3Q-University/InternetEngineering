using Core.Application.Restaurants.Commands.CreateRestaurant;
using Core.Application.Restaurants.Queries.GetRestaurantById;
using Core.Contracts.Restaurant.Request;
using Core.Contracts.Restaurant.Response;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class RestaurantMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Restaurant, RestaurantResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.MenuId, src => src.MenuId.Value);

            config.NewConfig<Guid, GetRestaurantByIdQuery>()
                .Map(dest => dest.Id, src => RestaurantId.Create(src));

            config.NewConfig<CreateRestaurantRequest, CreateRestaurantCommand>();

            config.NewConfig<RestaurantId, RestaurantId>()
                .MapWith(src => src);
        }
    }
}
