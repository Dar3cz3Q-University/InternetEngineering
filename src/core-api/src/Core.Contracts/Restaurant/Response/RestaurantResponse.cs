namespace Core.Contracts.Restaurant.Response
{
    public record RestaurantResponse(
        string Id,
        string Name,
        Address Location,
        string Description,
        ContactInfo ContactInfo,
        OpeningHours OpeningHours,
        bool IsOpen,
        string MenuId,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record Address(
        string Street,
        string City,
        string PostalCode);

    public record ContactInfo(
        string PhoneNumber,
        string Email);

    public record OpeningHours(
        DateTime OpenTime,
        DateTime CloseTime);

    public record Money(
        decimal Amount,
        string Currency);
}