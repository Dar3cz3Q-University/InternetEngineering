using Core.Domain.MenuAggregate.ValueObjects;
using ErrorOr;

namespace Core.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Menu
        {
            public static Error NotFound(MenuId id) => Error.NotFound(
                code: "Menu.NotFound",
                description: "Menu with ID: '" + id.Value.ToString() + "' doesn't exists.");
        }
    }
}