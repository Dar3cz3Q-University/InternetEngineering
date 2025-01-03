namespace Core.Application.Common.Commands
{
    public record CreateAddressCommand(
        string Street,
        string BuildingNumber,
        string? ApartmentNumber,
        string PostalCode,
        string City,
        string State,
        string Country,
        double? Latitude,
        double? Longitude);
}