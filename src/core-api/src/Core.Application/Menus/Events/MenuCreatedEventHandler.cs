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

        // TODO: [Change handlers to use async functions from repository #28]
        public Task Handle(
            MenuCreated notification,
            CancellationToken cancellationToken)
        {
            var restaurant = _restaurantRepository.GetById(notification.Menu.RestaurantId);

            restaurant!.AssignMenuId(notification.Menu.Id);

            _restaurantRepository.Update(restaurant);

            return Task.CompletedTask;
        }
    }
}
