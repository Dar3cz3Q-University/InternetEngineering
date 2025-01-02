namespace Core.Contracts.Common.Request
{
    public record MoneyRequest(
        decimal Amount,
        string Currency);
}
