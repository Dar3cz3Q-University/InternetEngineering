namespace Core.Contracts.Menu.Response
{
    public record MenuSectionResponse(
        string Id,
        string Name,
        string Description,
        List<MenuItemResponse> Items,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}