namespace Core.Contracts.Common.Request
{
    public record AddressRequest(
        string Street,
        string BuildingNumber,
        string? ApartmentNumber,
        string PostalCode,
        string City,
        string State,
        string Country,
        double Latitude,
        double Longitude);
}