namespace Core.Application.Common.Commands
{
    public record CreateContactInfoCommand(
        string PhoneNumber,
        string Email);
}