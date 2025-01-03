using Core.Domain.Common.ValueObjects;
using ErrorOr;

namespace Core.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Address
        {
            public static Error NotFound(AddressId id) => Error.NotFound(
                code: "Address.NotFound",
                description: "Address with ID: '" + id.Value.ToString() + "' doesn't exists.");
        }
    }
}