namespace Core.Contracts.Common.Response
{
    public record AddressResponse(
        string Id,
        string Street,
        string BuildingNumber,
        string? ApartmentNumber,
        string PostalCode,
        string City,
        string State,
        string Country,
        double Latitude,
        double Longitude,
        DateTime UpdatedDateTime,
        DateTime CreatedDateTime);
}