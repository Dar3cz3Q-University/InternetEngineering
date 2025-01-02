using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.RestaurantAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Commands.UpdateRestaurant
{
    // TODO: [Create update command handlers #42]
    public class UpdateRestaurantCommandHandler :
        IRequestHandler<UpdateRestaurantCommand, ErrorOr<Restaurant>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public UpdateRestaurantCommandHandler(
            IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Restaurant>> Handle(
            UpdateRestaurantCommand request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            throw new NotImplementedException();
        }
    }
}