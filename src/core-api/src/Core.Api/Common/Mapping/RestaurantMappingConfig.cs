using Core.Application.Restaurants.Commands.CreateRestaurant;
using Core.Application.Restaurants.Commands.DeleteRestaurant;
using Core.Application.Restaurants.Commands.UpdateRestaurant;
using Core.Application.Restaurants.Queries.GetRestaurant;
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
            //
            // Response
            //

            config.NewConfig<Restaurant, RestaurantResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.MenuId, src => src.MenuId.Value);

            //
            // Create
            //

            config.NewConfig<CreateRestaurantRequest, CreateRestaurantCommand>();

            config.NewConfig<CreateContactInfoRequest, CreateContactInfoCommand>();

            config.NewConfig<CreateOpeningHoursRequest, CreateOpeningHoursCommand>();

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

            config.NewConfig<Guid, GetRestaurantQuery>()
                .Map(dest => dest.RestaurantId, src => RestaurantId.Create(src));

            //
            // Utils
            //

            config.NewConfig<RestaurantId, RestaurantId>()
                .MapWith(src => src);
        }
    }
}