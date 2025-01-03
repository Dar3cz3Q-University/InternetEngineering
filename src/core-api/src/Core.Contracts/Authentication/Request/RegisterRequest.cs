using Core.Contracts.Authentication.DTO;
using Core.Contracts.Common.Request;

namespace Core.Contracts.Authentication.Request
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Password,
        UserRoleDTO UserRole,
        AddressRequest Address
    );
}