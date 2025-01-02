using Core.Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.UpdateOrder
{
    // TODO: [Create update command handlers #42]
    public record UpdateOrderCommand() : IRequest<ErrorOr<Order>>;
}
