using Core.Domain.Common.Models;

namespace Core.Domain.OrderAggregate.Events
{
    public record OrderCreated(Order Order) : IDomainEvent;
}