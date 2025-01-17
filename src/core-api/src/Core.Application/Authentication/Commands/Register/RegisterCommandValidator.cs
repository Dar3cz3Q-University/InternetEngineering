using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\d{9}$").WithMessage("Phone number must be 9 digits.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"\d").WithMessage("Password must contain at least one number.")
                .Matches(@"[\!\@\#\$\%\^\&\*\(\)_\+\-\=\[\]\{\};:'"",\.<>\/\?\\]").WithMessage("Password must contain at least one special character."); ;

            RuleFor(x => x.UserRole)
                .NotEmpty()
                .NotEqual(Domain.UserAggregate.UserRole.Admin)
                .IsInEnum();

            RuleFor(x => x.AvatarImage)
               .NotNull()
               .Must(BeAValidFile).WithMessage("Unsupported file format. Accepted are only JPG, JPEG, PNG.")
               .Must(BeWithinSizeLimit).WithMessage("File is too big. Max size is 10 MB.");

            //
            // Location
            //

            RuleFor(x => x.Address.Street)
                .NotEmpty();

            RuleFor(x => x.Address.BuildingNumber)
                .NotEmpty();

            RuleFor(x => x.Address.ApartmentNumber);

            RuleFor(x => x.Address.PostalCode)
                .NotEmpty()
                .Matches(@"^\d{2}-\d{3}$").WithMessage("Invalid postal code format. Expected format: 00-000.");

            RuleFor(x => x.Address.City)
                .NotEmpty();

            RuleFor(x => x.Address.State)
                .NotEmpty();

            RuleFor(x => x.Address.Country)
                .NotEmpty();

            RuleFor(x => x.Address.Latitude)
                .InclusiveBetween(-90, 90);

            RuleFor(x => x.Address.Longitude)
                .InclusiveBetween(-180, 180);

            RuleFor(x => x.MaxSearchDistance)
                .NotEmpty()
                .GreaterThan(0);
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