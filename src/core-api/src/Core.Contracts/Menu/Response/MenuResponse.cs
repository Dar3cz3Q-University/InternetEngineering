namespace Core.Contracts.Menu.Response
{
    public record MenuResponse(
        string Id,
        string Name,
        string Description,
        List<MenuSectionResponse> Sections,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record MenuSectionResponse(
        string Id,
        string Name,
        string Description,
        List<MenuItemResponse> Items,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record MenuItemResponse(
        string Id,
        string Name,
        string Description,
        MoneyResponse Price,
        bool IsAvailable,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record MoneyResponse(
        decimal Amount,
        string Currency);
}