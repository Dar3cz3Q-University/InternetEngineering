using FluentValidation;

namespace Core.Application.Favorites.Commands.AddFavorite
{
    public class AddFavoriteCommandValidator
        : AbstractValidator<AddFavoriteCommand>
    {
        public AddFavoriteCommandValidator()
        {
            RuleFor(x => x.RestaurantId)
                .NotEmpty();
        }
    }
}