using Core.Application.Menu.Commands.CreateMenuItem;
using Core.Application.Menu.Commands.CreateMenuSection;
using Core.Contracts.Menu.Request;
using Core.Contracts.Menu.Response;
using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //
            // Response
            //

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.ImageUrl, src => $"http://192.168.0.5:8080/{src.ImageUrl}");

            //
            // Create
            //

            config.NewConfig<(Guid, CreateMenuSectionRequest), CreateMenuSectionCommand>()
                .Map(dest => dest.RestaurantId, src => RestaurantId.Create(src.Item1))
                .Map(dest => dest, src => src.Item2);

            config.NewConfig<(Guid, Guid, CreateMenuItemRequest), CreateMenuItemCommand>()
                .Map(dest => dest.RestaurantId, src => RestaurantId.Create(src.Item1))
                .Map(dest => dest.MenuSectionId, src => MenuSectionId.Create(src.Item2))
                .Map(dest => dest, src => src.Item3);

            //
            // Delete
            //



            //
            // Update
            //



            //
            // Get
            //



            //
            // Utils
            //

            config.NewConfig<MenuId, MenuId>()
                .MapWith(src => src);

            config.NewConfig<MenuItemId, MenuItemId>()
                .MapWith(src => src);

            config.NewConfig<MenuSectionId, MenuSectionId>()
                .MapWith(src => src);
        }
    }
}