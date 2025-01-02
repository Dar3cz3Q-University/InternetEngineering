namespace Core.Application.Common.Commands
{
    public record CreateAddressCommand(
        string Street,
        string City,
        string PostalCode);
}
