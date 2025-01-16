using Core.Application.Common.Config;
using Core.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Services
{
    public class ImageSaver : IImageSaver
    {
        private readonly IWebHostEnvironment _environment;

        public ImageSaver(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> Save(
            IFormFile file,
            string type,
            CancellationToken cancellationToken)
        {
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var uploadPath = Path.Combine(
                _environment.WebRootPath,
                type);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            return $"{type}/{uniqueFileName}";
        }
    }
}