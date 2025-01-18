using Microsoft.AspNetCore.Http;

namespace Core.Contracts.Category.Request
{
    public record CreateCategoryRequest(
        string Name,
        IFormFile Image);
}
