using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.RestaurantAggregate.Entities;
using ErrorOr;
using MediatR;

namespace Core.Application.Menu.Commands.CreateMenuSection
{
    public class CreateMenuSectionCommandHandler
        : IRequestHandler<CreateMenuSectionCommand, ErrorOr<MenuSection>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public CreateMenuSectionCommandHandler(
            IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ErrorOr<MenuSection>> Handle(
            CreateMenuSectionCommand request,
            CancellationToken cancellationToken)
        {
            var restaurantResult = await _restaurantRepository.GetByIdAsync(request.RestaurantId);

            if (restaurantResult.IsError)
                return restaurantResult.Errors;

            var restaurant = restaurantResult.Value;

            var section = MenuSection.Create(
                request.Name,
                request.Description);

            restaurant.AddMenuSection(section);

            await _restaurantRepository.UpdateAsync(restaurant);

            return section;
        }
    }
}