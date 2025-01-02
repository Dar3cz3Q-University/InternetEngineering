using Core.Contracts.Common.Response;

namespace Core.Contracts.Restaurant.Response
{
    public record RestaurantResponse(
        string Id,
        string Name,
        AddressResponse Location,
        string Description,
        ContactInfo ContactInfo,
        OpeningHours OpeningHours,
        string MenuId,
        bool IsOpen,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record ContactInfo(
        string PhoneNumber,
        string Email);

    public record OpeningHours(
        DateTime OpenTime,
        DateTime CloseTime);
}