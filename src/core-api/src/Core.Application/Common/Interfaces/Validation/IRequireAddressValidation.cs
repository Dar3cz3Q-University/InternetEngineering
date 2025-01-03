using Core.Domain.Common.ValueObjects;

namespace Core.Application.Common.Interfaces.Validation
{
    public interface IRequireAddressValidation
    {
        AddressId AddressId { get; }
    }
}