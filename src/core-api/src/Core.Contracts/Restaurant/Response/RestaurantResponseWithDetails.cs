using Core.Contracts.Common.Response;
using Core.Contracts.Menu.Response;

namespace Core.Contracts.Restaurant.Response
{
    public record RestaurantResponseWithDetails(
        string Id,
        string Name,
        string Description,
        string ImageUrl,
        double? Distance,
        double AverageRate,
        double RateCount,
        bool IsActive,
        AddressResponse Location,
        ContactInfoResponse ContactInfo,
        OpeningHours OpeningHours,
        MenuResponse Menu,
        DateTime UpdatedDateTime,
        DateTime CreatedDateTime);
}