using FluentValidation;

namespace Core.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.RestaurantId).NotEmpty();
            RuleFor(x => x.AddressId).NotEmpty();
            RuleForEach(x => x.ItemsIds)
                .NotEmpty()
                .Must(item => item.Quantity > 0);
        }
    }
}