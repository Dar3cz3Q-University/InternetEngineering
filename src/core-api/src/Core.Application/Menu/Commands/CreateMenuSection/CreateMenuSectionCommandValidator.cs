using FluentValidation;

namespace Core.Application.Menu.Commands.CreateMenuSection
{
    public class CreateMenuSectionCommandValidator
        : AbstractValidator<CreateMenuSectionCommand>
    {
        public CreateMenuSectionCommandValidator()
        {
            // TODO: [Add validations #26]
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}