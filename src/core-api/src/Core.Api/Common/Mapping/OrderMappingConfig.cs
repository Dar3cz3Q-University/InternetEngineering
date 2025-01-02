using Core.Application.Orders.Commands.CreateOrder;
using Core.Application.Orders.Commands.DeleteOrder;
using Core.Application.Orders.Queries.GetOrder;
using Core.Contracts.Order.Request;
using Core.Contracts.Order.Response;
using Core.Domain.MenuAggregate.ValueObjects;
using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class OrderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //
            // Response
            //

            config.NewConfig<Order, OrderResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value)
                .Map(dest => dest.RestaurantId, src => src.RestaurantId.Value);

            //
            // Create
            //

            config.NewConfig<CreateOrderRequest, CreateOrderCommand>()
                .Map(dest => dest.UserId, src => UserId.Create(src.UserId))
                .Map(dest => dest.RestaurantId, src => RestaurantId.Create(src.RestaurantId));

            config.NewConfig<List<Guid>, List<MenuItemId>>()
                .MapWith(src => src.ConvertAll(i => MenuItemId.Create(i)));

            //
            // Delete
            //

            config.NewConfig<Guid, DeleteOrderCommand>()
                .Map(dest => dest.OrderId, src => OrderId.Create(src));

            //
            // Update
            //



            //
            // Get
            //

            config.NewConfig<Guid, GetOrderQuery>()
               .Map(dest => dest.OrderId, src => OrderId.Create(src));

            //
            // Utils
            //

            config.NewConfig<OrderId, OrderId>()
                .MapWith(src => src);
        }
    }
}
