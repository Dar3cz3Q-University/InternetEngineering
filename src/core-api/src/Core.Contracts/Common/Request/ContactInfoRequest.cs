namespace Core.Contracts.Common.Request
{
    public record ContactInfoRequest(
        string PhoneNumber,
        string Email);
}