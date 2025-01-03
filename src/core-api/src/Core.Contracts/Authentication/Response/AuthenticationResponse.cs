using Core.Contracts.Authentication.DTO;
using Core.Contracts.Common.Response;

namespace Core.Contracts.Authentication.Response
{
    public record AuthenticationResponse(
        string Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        UserRoleDTO UserRole,
        List<AddressResponse> Addresses,
        string Token,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime
    );
}