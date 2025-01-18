using Core.Contracts.Common.Request;
using Microsoft.AspNetCore.Http;

namespace Core.Contracts.Restaurant.Request
{
    public record CreateRestaurantRequest(
        string Name,
        string Description,
        IFormFile Image,
        AddressRequest Location,
        ContactInfoRequest ContactInfo,
        List<Guid> Categories,
        OpeningHoursRequest OpeningHours);
}