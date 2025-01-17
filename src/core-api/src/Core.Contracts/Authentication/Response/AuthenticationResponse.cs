using Core.Contracts.Authentication.DTO;
using Core.Contracts.Common.Response;

namespace Core.Contracts.Authentication.Response
{
    public record AuthenticationResponse(
        string Id,
        string ImageUrl,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        UserRoleDTO UserRole,
        List<AddressResponse> Addresses,
        double MaxSearchDistance,
        string Token,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime
    );
}