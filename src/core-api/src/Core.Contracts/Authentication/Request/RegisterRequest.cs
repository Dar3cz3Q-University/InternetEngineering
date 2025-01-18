using Core.Contracts.Authentication.DTO;
using Core.Contracts.Common.Request;
using Microsoft.AspNetCore.Http;

namespace Core.Contracts.Authentication.Request
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Password,
        UserRoleDTO UserRole,
        IFormFile Image,
        AddressRequest Address,
        double MaxSearchDistance);
}