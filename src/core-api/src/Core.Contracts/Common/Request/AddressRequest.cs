namespace Core.Contracts.Common.Request
{
    public record AddressRequest(
        string Street,
        string City,
        string PostalCode);
}