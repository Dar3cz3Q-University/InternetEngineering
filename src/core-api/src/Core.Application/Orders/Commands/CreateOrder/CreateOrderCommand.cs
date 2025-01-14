using Core.Application.Common.Interfaces.Validation;
using Core.Domain.Common.ValueObjects;
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
        AddressId AddressId,
        List<MenuItemId> ItemsIds) : IRequest<ErrorOr<Order>>, IRequireUserValidation, IRequireRestaurantValidation;
}