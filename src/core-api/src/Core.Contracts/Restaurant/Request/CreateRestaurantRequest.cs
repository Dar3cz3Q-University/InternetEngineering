using Core.Contracts.Common.Request;

namespace Core.Contracts.Restaurant.Request
{
    public record CreateRestaurantRequest(
        string Name,
        AddressRequest Location,
        string Description,
        ContactInfoRequest ContactInfo,
        OpeningHoursRequest OpeningHours);
}