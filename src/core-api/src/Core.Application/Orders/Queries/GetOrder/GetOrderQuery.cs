using Core.Application.Orders.Common;
using Core.Domain.OrderAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetOrder
{
    public record GetOrderQuery(
        OrderId OrderId) : IRequest<ErrorOr<OrderWithDetailsDTO>>;
}