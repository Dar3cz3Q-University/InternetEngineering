using Core.Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetOrders
{
    public record GetOrdersQuery() : IRequest<ErrorOr<List<Order>>>;
}
