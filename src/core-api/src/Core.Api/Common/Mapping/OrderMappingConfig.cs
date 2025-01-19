using Core.Application.Orders.Commands.CreateOrder;
using Core.Application.Orders.Commands.DeleteOrder;
using Core.Application.Orders.Common;
using Core.Application.Orders.Queries.GetOrder;
using Core.Contracts.Order.Request;
using Core.Contracts.Order.Response;
using Core.Domain.Common.ValueObjects;
using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;
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

            config.NewConfig<OrderDTO, OrderResponse>()
                .Map(dest => dest.Id, src => src.Order.Id.Value)
                .Map(dest => dest.RestaurantName, src => src.Restaurant.Name)
                .Map(dest => dest.ImageUrl, src => src.Restaurant.ImageUrl)
                .Map(dest => dest.OrderStatus, src => ConvertToString(src.Order.OrderStatus))
                .Map(dest => dest.IsActive, src => IsActive(src.Order.OrderStatus))
                .Map(dest => dest.CreatedDateTime, src => src.Order.CreatedDateTime)
                .Map(dest => dest.UpdatedDateTime, src => src.Order.UpdatedDateTime);

            config.NewConfig<OrderWithDetailsDTO, OrderResponseWithDetails>()
                .Map(dest => dest.Id, src => src.Order.Id.Value)
                .Map(dest => dest.OrderStatus, src => ConvertToString(src.Order.OrderStatus))
                .Map(dest => dest.Restaurant, src => src.Restaurant)
                .Map(dest => dest.DeliveryAddress, src => src.DeliveryAddress)
                .Map(dest => dest.Items, src => src.Items.Adapt<List<ItemReponse>>())
                .Map(dest => dest.TotalPrice, src => src.Order.TotalPrice)
                .Map(dest => dest.CourierName, src => src.Courier.FirstName)
                .Map(dest => dest.IsActive, src => IsActive(src.Order.OrderStatus))
                .Map(dest => dest.EstimatedDeliveryDateTime, src => src.Order.DeliveryTime)
                .Map(dest => dest.CreatedDateTime, src => src.Order.CreatedDateTime)
                .Map(dest => dest.UpdatedDateTime, src => src.Order.UpdatedDateTime);

            config.NewConfig<OrderedItemDTO, ItemReponse>()
                .Map(dest => dest.Id, src => src.MenuItem.Id.Value)
                .Map(dest => dest.Name, src => src.MenuItem.Name)
                //.Map(dest => dest.ImageUrl, src => src.MenuItem.ImageUrl)
                .Map(dest => dest.Price, src => src.MenuItem.Price)
                .Map(dest => dest.Quantity, src => src.Quantity);

            //
            // Create
            //

            config.NewConfig<CreateOrderRequest, CreateOrderCommand>()
                .Map(dest => dest.RestaurantId, src => RestaurantId.Create(src.RestaurantId))
                .Map(dest => dest.AddressId, src => AddressId.Create(src.DeliveryAddressId))
                .Map(dest => dest.ItemsIds, src => src.Items.Adapt<List<ItemCommand>>());

            config.NewConfig<ItemRequest, ItemCommand>()
                .Map(dest => dest.ItemId, src => MenuItemId.Create(src.ItemId));


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

            config.NewConfig<OrderedItemId, OrderedItemId>()
                .MapWith(src => src);
        }

        private static bool IsActive(OrderStatus orderStatus)
        {
            if (orderStatus == OrderStatus.Cancelled || orderStatus == OrderStatus.Delivered)
            {
                return false;
            }

            return true;
        }

        private static string ConvertToString(OrderStatus orderStatus)
        {
            return orderStatus switch
            {
                OrderStatus.Cancelled => "Cancelled",
                OrderStatus.Pending => "Pending",
                OrderStatus.Accepted => "Accepted",
                OrderStatus.InPreparation => "In Progress",
                OrderStatus.ReadyForCollection => "Ready For Collection",
                OrderStatus.InDelivery => "In Delivery",
                OrderStatus.Delivered => "Delivered",
                _ => throw new ApplicationException("Invalid order status enum."),
            };
        }
    }
}