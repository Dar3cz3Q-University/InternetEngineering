using Core.Contracts.Common.Request;

namespace Core.Contracts.Restaurant.Request
{
    public record UpdateRestaurantRequest(
        Guid RestaurantId,
        string Name,
        AddressRequest Location,
        string Description,
        Guid MenuId,
        UpdateContactInfoRequest ContactInfo,
        UpdateOpeningHoursRequest OpeningHours,
        bool IsOpen);

    public record UpdateContactInfoRequest(
        string PhoneNumber,
        string Email);

    public record UpdateOpeningHoursRequest(
        DateTime OpenTime,
        DateTime CloseTime);
}
