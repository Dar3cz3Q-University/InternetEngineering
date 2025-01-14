using Core.Application.Common.Interfaces.Persistance;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Commands.DeleteRestaurant
{
    internal class DeleteRestaurantCommandHandler :
        IRequestHandler<DeleteRestaurantCommand, ErrorOr<Deleted>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public DeleteRestaurantCommandHandler(
            IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteRestaurantCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _restaurantRepository.DeleteByIdAsync(request.RestaurantId);

            // TODO: Check for more specific error
            if (result.IsError)
                throw new ApplicationException("Failed to remove restaurant from database.");

            return Result.Deleted;
        }
    }
}