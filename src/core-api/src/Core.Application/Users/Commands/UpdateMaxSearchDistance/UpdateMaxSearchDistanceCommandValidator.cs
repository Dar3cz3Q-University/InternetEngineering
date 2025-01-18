using FluentValidation;

namespace Core.Application.Users.Commands.UpdateMaxSearchDistance
{
    public class UpdateMaxSearchDistanceCommandValidator
        : AbstractValidator<UpdateMaxSearchDistanceCommand>
    {
        public UpdateMaxSearchDistanceCommandValidator()
        {
            RuleFor(x => x.MaxSearchDistance)
                .GreaterThan(0);
        }
    }
}
