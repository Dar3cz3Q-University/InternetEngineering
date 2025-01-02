using Core.Contracts.Common.Request;

namespace Core.Contracts.Restaurant.Request
{
    public record CreateRestaurantRequest(
        string Name,
        AddressRequest Location,
        string Description,
        CreateContactInfoRequest ContactInfo,
        CreateOpeningHoursRequest OpeningHours);

    public record CreateContactInfoRequest(
        string PhoneNumber,
        string Email);

    public record CreateOpeningHoursRequest(
        DateTime OpenTime,
        DateTime CloseTime);
}