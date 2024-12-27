namespace Core.Contracts.Authentication.Request
{
    public record LoginRequest(
        string Email,
        string Password
    );
}