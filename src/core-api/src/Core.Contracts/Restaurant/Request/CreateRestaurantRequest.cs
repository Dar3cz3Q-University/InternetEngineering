namespace Core.Contracts.Restaurant.Request
{
    public record CreateRestaurantRequest(
        string Name,
        CreateAddressRequest Location,
        string Description,
        CreateContactInfoRequest ContactInfo,
        CreateOpeningHoursRequest OpeningHours);

    public record CreateAddressRequest(
        string Street,
        string City,
        string PostalCode);

    public record CreateContactInfoRequest(
        string PhoneNumber,
        string Email);

    public record CreateOpeningHoursRequest(
        DateTime OpenTime,
        DateTime CloseTime);
}