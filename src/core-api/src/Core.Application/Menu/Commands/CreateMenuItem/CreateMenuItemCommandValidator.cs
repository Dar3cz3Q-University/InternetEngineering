using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Menu.Commands.CreateMenuItem
{
    public class CreateMenuItemCommandValidator
        : AbstractValidator<CreateMenuItemCommand>
    {
        public CreateMenuItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(x => x.Price.Amount)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Price.Currency)
                .NotEmpty();

            RuleFor(x => x.Image)
               .NotNull()
               .Must(BeAValidFile).WithMessage("Unsupported file format. Accepted are only JPG, JPEG, PNG.")
               .Must(BeWithinSizeLimit).WithMessage("File is too big. Max size is 10 MB.");
        }

        private static bool BeAValidFile(IFormFile file)
        {
            if (file == null) return false;

            var allowedContentTypes = new[] { "image/jpeg", "image/png" };
            return allowedContentTypes.Contains(file.ContentType);
        }

        private static bool BeWithinSizeLimit(IFormFile file)
        {
            if (file == null) return false;

            const long maxSizeInBytes = 10 * 1024 * 1024;
            return file.Length <= maxSizeInBytes;
        }
    }
}