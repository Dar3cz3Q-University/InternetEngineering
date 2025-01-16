using FluentValidation;

namespace Core.Application.Restaurants.Queries.GetRestaurants
{
    public class GetRestaurantsQueryValidator
        : AbstractValidator<GetRestaurantsQuery>
    {
        public GetRestaurantsQueryValidator()
        {
            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90);

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180);
        }
    }
}