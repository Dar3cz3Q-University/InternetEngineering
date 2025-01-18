using FluentValidation;

namespace Core.Application.Restaurants.Queries.GetRestaurant
{
    public class GetRestaurantQueryValidator
        : AbstractValidator<GetRestaurantQuery>
    {
        public GetRestaurantQueryValidator()
        {
            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90);

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180);
        }
    }
}
