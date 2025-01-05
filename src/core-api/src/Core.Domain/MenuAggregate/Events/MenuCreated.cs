using Core.Domain.Common.Models;
using Core.Domain.MenuAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.MenuAggregate.Events
{
    public record MenuCreated(
        MenuId MenuId,
        RestaurantId RestaurantId) : IDomainEvent;
}