using FluentValidation;

namespace Core.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(x => x.ContactInfo.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\d{9}$").WithMessage("Phone number must be 9 digits.");

            RuleFor(x => x.ContactInfo.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Location.Street)
                .NotEmpty();

            RuleFor(x => x.Location.BuildingNumber)
                .NotEmpty();

            RuleFor(x => x.Location.ApartmentNumber);

            RuleFor(x => x.Location.PostalCode)
                .NotEmpty()
                .Matches(@"^\d{2}-\d{3}$").WithMessage("Invalid postal code format. Expected format: 00-000.");

            RuleFor(x => x.Location.City)
                .NotEmpty();

            RuleFor(x => x.Location.State)
                .NotEmpty();

            RuleFor(x => x.Location.Country)
                .NotEmpty();

            RuleFor(x => x.Location.Latitude)
                .InclusiveBetween(-90, 90);

            RuleFor(x => x.Location.Longitude)
                .InclusiveBetween(-180, 180);

            RuleFor(x => x.OpeningHours.OpenTime)
                .NotEmpty();

            RuleFor(x => x.OpeningHours.CloseTime)
                .NotEmpty();
        }
    }
}