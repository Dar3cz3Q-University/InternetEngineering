using Core.Contracts.Common.Request;

namespace Core.Contracts.Restaurant.Request
{
    public record UpdateRestaurantRequest(
        Guid RestaurantId,
        string Name,
        AddressRequest Location,
        string Description,
        Guid MenuId,
        ContactInfoRequest ContactInfo,
        UpdateOpeningHoursRequest OpeningHours,
        bool IsOpen);

    public record UpdateOpeningHoursRequest(
        DateTime OpenTime,
        DateTime CloseTime);
}