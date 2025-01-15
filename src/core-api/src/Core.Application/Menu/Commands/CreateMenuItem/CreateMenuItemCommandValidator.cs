using FluentValidation;

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
        }
    }
}