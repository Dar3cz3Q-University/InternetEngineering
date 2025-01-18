namespace Core.Contracts.Category.Response
{
    public record CategoryResponse(
        string Id,
        string Name,
        string ImageUrl,
        DateTime UpdatedDateTime,
        DateTime CreatedDateTime);
}
