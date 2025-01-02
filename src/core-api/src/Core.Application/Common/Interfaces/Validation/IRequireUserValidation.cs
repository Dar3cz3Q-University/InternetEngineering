using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Validation
{
    public interface IRequireUserValidation
    {
        UserId UserId { get; }
    }
}
