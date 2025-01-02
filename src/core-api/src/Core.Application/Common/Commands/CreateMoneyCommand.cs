namespace Core.Application.Common.Commands
{
    public record CreateMoneyCommand(
        decimal Amount,
        string Currency);
}