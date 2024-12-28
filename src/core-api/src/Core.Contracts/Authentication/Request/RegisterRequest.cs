using Core.Contracts.Authentication.DTO;

namespace Core.Contracts.Authentication.Request
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Password,
        UserRoleDTO UserRole
    );
}