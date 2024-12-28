using Core.Contracts.Authentication.DTO;

namespace Core.Contracts.Authentication.Response
{
    public record AuthenticationResponse(
        string Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        UserRoleDTO UserRole,
        string Token,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime
    );
}