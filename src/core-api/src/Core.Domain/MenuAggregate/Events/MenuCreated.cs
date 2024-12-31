using Core.Domain.Common.Models;

namespace Core.Domain.MenuAggregate.Events
{
    public record MenuCreated(Menu Menu) : IDomainEvent;
}