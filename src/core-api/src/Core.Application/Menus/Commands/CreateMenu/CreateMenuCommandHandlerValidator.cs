using FluentValidation;

namespace Core.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandlerValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandHandlerValidator()
        {
            // TODO: [Add validations #26]
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.RestaurantId).NotEmpty();
        }
    }
}