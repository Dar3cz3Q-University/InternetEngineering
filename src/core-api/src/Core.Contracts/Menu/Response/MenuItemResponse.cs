using Core.Contracts.Common.Response;

namespace Core.Contracts.Menu.Response
{
    public record MenuItemResponse(
        string Id,
        string Name,
        string Description,
        MoneyResponse Price,
        bool IsAvailable,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}