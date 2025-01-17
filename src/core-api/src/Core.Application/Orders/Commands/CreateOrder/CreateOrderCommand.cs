using Core.Application.Common.Interfaces.Validation;
using Core.Application.Orders.Common;
using Core.Domain.Common.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(
        RestaurantId RestaurantId,
        AddressId AddressId,
        List<ItemCommand> ItemsIds) : IRequest<ErrorOr<OrderDTO>>, IRequireRestaurantValidation, IRequireAddressValidation;

    public record ItemCommand(
        MenuItemId ItemId,
        uint Quantity);
}