using FluentValidation;

namespace Core.Application.Menu.Commands.CreateMenuItem
{
    public class CreateMenuItemCommandValidator
        : AbstractValidator<CreateMenuItemCommand>
    {
        public CreateMenuItemCommandValidator()
        {
            // TODO: [Add validations #26]
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}