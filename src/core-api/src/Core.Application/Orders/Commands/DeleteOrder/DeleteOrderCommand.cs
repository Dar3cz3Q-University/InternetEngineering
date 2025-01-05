using Core.Application.Common.Interfaces.Validation;
using Core.Domain.OrderAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.DeleteOrder
{
    public record DeleteOrderCommand(
        OrderId OrderId) : IRequest<ErrorOr<Deleted>>, IRequireOrderValidation;
}