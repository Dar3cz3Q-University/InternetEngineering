using Core.Application.Common.Interfaces.Validation;
using Core.Domain.OrderAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.TakeOrder
{
    public record TakeOrderCommand(
        OrderId OrderId) : IRequest<ErrorOr<Updated>>, IRequireOrderValidation;
}
