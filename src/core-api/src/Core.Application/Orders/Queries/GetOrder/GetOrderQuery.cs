using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetOrder
{
    public record GetOrderQuery(
        OrderId OrderId) : IRequest<ErrorOr<Order>>;
}
