namespace Core.Contracts.Menu.Response
{
    public record MenuResponse(
        string Id,
        List<MenuSectionResponse> Sections,
        DateTime UpdatedDateTime,
        DateTime CreatedDateTime);
}