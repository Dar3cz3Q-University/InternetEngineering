using Core.Application.Menus.Commands.CreateMenu;
using Core.Application.Menus.Commands.DeleteMenu;
using Core.Application.Menus.Queries.GetMenu;
using Core.Contracts.Menu.Request;
using Core.Contracts.Menu.Response;
using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.Entities;
using Core.Domain.MenuAggregate.ValueObjects;
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
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.RestaurantId, src => src.RestaurantId.Value);

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            //
            // Create
            //

            config.NewConfig<CreateMenuRequest, CreateMenuCommand>()
                .Map(dest => dest.RestaurantId, src => RestaurantId.Create(src.RestaurantId));

            config.NewConfig<CreateMenuSectionRequest, CreateMenuSectionComand>();

            config.NewConfig<CreateMenuItemRequest, CreateMenuItemCommand>();

            //
            // Delete
            //

            config.NewConfig<Guid, DeleteMenuCommand>()
                .Map(dest => dest.MenuId, src => MenuId.Create(src));

            //
            // Update
            //



            //
            // Get
            //

            config.NewConfig<Guid, GetMenuQuery>()
                .Map(dest => dest.MenuId, src => MenuId.Create(src));

            //
            // Utils
            //

            config.NewConfig<MenuId, MenuId>()
                .MapWith(src => src);
        }
    }
}