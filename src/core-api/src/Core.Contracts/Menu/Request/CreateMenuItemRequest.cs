using Core.Contracts.Common.Request;

namespace Core.Contracts.Menu.Request
{
    public record CreateMenuItemRequest(
        string Name,
        string Description,
        MoneyRequest Price);
}