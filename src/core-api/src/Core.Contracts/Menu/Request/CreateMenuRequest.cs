namespace Core.Contracts.Menu.Request
{
    public record CreateMenuRequest(
        string Name,
        string Description,
        string RestaurantId,
        List<CreateMenuSectionRequest> Sections);

    public record CreateMenuSectionRequest(
        string Name,
        string Description,
        List<CreateMenuItemRequest> Items);

    public record CreateMenuItemRequest(
        string Name,
        string Description,
        CreateMoneyRequest Price);

    public record CreateMoneyRequest(
        decimal Amount,
        string Currency);
}
