using Core.Contracts.Common.Request;
using Microsoft.AspNetCore.Http;

namespace Core.Contracts.Menu.Request
{
    public record CreateMenuItemRequest(
        string Name,
        IFormFile Image,
        string Description,
        MoneyRequest Price);
}