using Core.Domain.MenuAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Validation
{
    public interface IRequireMenuValidation
    {
        MenuId MenuId { get; }
    }
}