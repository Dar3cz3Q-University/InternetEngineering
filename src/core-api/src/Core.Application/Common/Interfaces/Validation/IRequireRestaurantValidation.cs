using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Validation
{
    public interface IRequireRestaurantValidation
    {
        RestaurantId RestaurantId { get; }
    }
}
