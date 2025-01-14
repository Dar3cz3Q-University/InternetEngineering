using Core.Contracts.Common.Response;
using Core.Contracts.Menu.Response;

namespace Core.Contracts.Restaurant.Response
{
    public record RestaurantResponseWithDetails(
        string Id,
        string Name,
        AddressResponse Location,
        string Description,
        ContactInfoResponse ContactInfo,
        OpeningHours OpeningHours,
        MenuResponse Menu,
        bool IsOpen,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}