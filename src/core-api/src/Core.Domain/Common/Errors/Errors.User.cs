using Core.Domain.UserAggregate.ValueObjects;
using ErrorOr;

namespace Core.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error NotFound(UserId id) => Error.NotFound(
                code: "User.NotFound",
                description: "User with ID: '" + id.Value.ToString() + "' doesn't exists.");
            public static Error NotFoundByEmail(string email) => Error.NotFound(
                code: "User.NotFoundByEmail",
                description: "User with email: '" + email + "' doesn't exists.");
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is already in use.");
        }
    }
}