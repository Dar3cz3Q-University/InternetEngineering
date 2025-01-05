using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.MenuAggregate.Events;
using MediatR;

namespace Core.Application.Menus.Events
{
    internal class MenuCreatedEventHandler : INotificationHandler<MenuCreated>
    {
        public readonly IRestaurantRepository _restaurantRepository;

        public MenuCreatedEventHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task Handle(
            MenuCreated notification,
            CancellationToken cancellationToken)
        {
            var restaurantResult = await _restaurantRepository.GetByIdAsync(notification.RestaurantId);

            var restaurant = restaurantResult.Value;

            restaurant!.AssignMenuId(notification.MenuId);

            var result = await _restaurantRepository.UpdateAsync(restaurant);

            // TODO: Check for more specific error
            if (result.IsError)
            {
                throw new ApplicationException("Failed to update restaurant in database.");
            }

            return;
        }
    }
}