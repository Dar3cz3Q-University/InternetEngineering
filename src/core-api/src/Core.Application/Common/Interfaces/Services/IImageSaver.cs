using Microsoft.AspNetCore.Http;

namespace Core.Application.Common.Interfaces.Services
{
    public interface IImageSaver
    {
        Task<string> Save(IFormFile file, string type, CancellationToken cancellationToken);
    }
}