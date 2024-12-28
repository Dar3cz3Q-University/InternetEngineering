using Core.Application.Menus.Commands.CreateMenu;
using Core.Contracts.Menu.Request;
using Core.Contracts.Menu.Response;
using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.Entities;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.RestaurantId, src => src.RestaurantId.Value);

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<CreateMenuRequest, CreateMenuCommand>();

            config.NewConfig<CreateMenuSectionRequest, CreateMenuSectionComand>();

            config.NewConfig<CreateMenuItemRequest, CreateMenuItemCommand>();
        }
    }
}
