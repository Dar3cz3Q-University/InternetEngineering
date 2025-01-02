using Core.Application.Common.Interfaces.Persistance;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Commands.DeleteRestaurant
{
    internal class DeleteRestaurantCommandHandler :
        IRequestHandler<DeleteRestaurantCommand, ErrorOr<Unit>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public DeleteRestaurantCommandHandler(
            IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Unit>> Handle(
            DeleteRestaurantCommand request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _restaurantRepository.Delete(request.RestaurantId);

            return Unit.Value;
        }
    }
}
