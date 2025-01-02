using Core.Application.Common.Commands;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.MenuAggregate.ValueObjects;
using Core.Domain.OrderAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(
        UserId UserId,
        RestaurantId RestaurantId,
        CreateAddressCommand DeliveryAddress,
        List<MenuItemId> ItemsIds) : IRequest<ErrorOr<Order>>, IRequireUserValidation, IRequireRestaurantValidation;
}
