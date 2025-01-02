using Core.Contracts.Common.Request;

namespace Core.Contracts.Menu.Request
{
    public record CreateMenuRequest(
        string Name,
        string Description,
        Guid RestaurantId,
        List<CreateMenuSectionRequest> Sections);

    public record CreateMenuSectionRequest(
        string Name,
        string Description,
        List<CreateMenuItemRequest> Items);

    public record CreateMenuItemRequest(
        string Name,
        string Description,
        MoneyRequest Price);
}