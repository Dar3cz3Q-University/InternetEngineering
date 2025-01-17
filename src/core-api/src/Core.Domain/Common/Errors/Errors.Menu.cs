using Core.Domain.RestaurantAggregate.ValueObjects;
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

            public static Error NotFound(MenuSectionId id) => Error.NotFound(
                code: "MenuSection.NotFound",
                description: "Menu section with ID: '" + id.Value.ToString() + "' doesn't exists.");

            public static Error NotFound(MenuItemId id) => Error.NotFound(
                code: "MenuItem.NotFound",
                description: "Menu item with ID: '" + id.Value.ToString() + "' doesn't exists.");
        }
    }
}