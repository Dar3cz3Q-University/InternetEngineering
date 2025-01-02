using FluentValidation;

namespace Core.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            // TODO: [Add validations #26]
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.RestaurantId).NotEmpty();

            RuleFor(x => x.DeliveryAddress.Street).NotEmpty();
            RuleFor(x => x.DeliveryAddress.City).NotEmpty();
            RuleFor(x => x.DeliveryAddress.PostalCode).NotEmpty();

            RuleFor(x => x.ItemsIds).NotEmpty();
        }
    }
}
