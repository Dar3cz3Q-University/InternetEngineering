using FluentValidation;

namespace Core.Application.Users.Commands.AddAddress
{
    public class AddAddressCommandValidator
        : AbstractValidator<AddAddressCommand>
    {
        public AddAddressCommandValidator()
        {
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
        }
    }
}