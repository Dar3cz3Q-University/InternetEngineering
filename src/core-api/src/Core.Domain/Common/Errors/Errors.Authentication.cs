using ErrorOr;

namespace Core.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Auth.InvalidCred",
                description: "Invalid credentials.");

            public static Error InsufficientPermissions => Error.Unauthorized(
                code: "Auth.InsufficientPermissions",
                description: "Insufficient permissions.");
        }
    }
}