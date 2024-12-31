using FluentValidation;

namespace Core.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            // TODO: [Add validations #26]
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Location.Street).NotEmpty();
            RuleFor(x => x.Location.City).NotEmpty();
            RuleFor(x => x.Location.PostalCode).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.ContactInfo.PhoneNumber).NotEmpty();
            RuleFor(x => x.ContactInfo.Email).NotEmpty();

            RuleFor(x => x.OpeningHours.OpenTime).NotEmpty();
            RuleFor(x => x.OpeningHours.CloseTime).NotEmpty();
        }
    }
}