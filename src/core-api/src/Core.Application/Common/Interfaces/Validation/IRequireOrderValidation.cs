using Core.Domain.OrderAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Validation
{
    public interface IRequireOrderValidation
    {
        OrderId OrderId { get; }
    }
}