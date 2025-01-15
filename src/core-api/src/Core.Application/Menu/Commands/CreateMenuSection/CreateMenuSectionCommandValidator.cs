using FluentValidation;

namespace Core.Application.Menu.Commands.CreateMenuSection
{
    public class CreateMenuSectionCommandValidator
        : AbstractValidator<CreateMenuSectionCommand>
    {
        public CreateMenuSectionCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(1000);
        }
    }
}