using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.ValueObjects;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler :
        IRequestHandler<CreateRestaurantCommand, ErrorOr<Restaurant>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public CreateRestaurantCommandHandler(
            IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Restaurant>> Handle(
            CreateRestaurantCommand request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var restaurant = Restaurant.Create(
                request.Name,
                Address.Create(
                    request.Location.Street,
                    request.Location.City,
                    request.Location.PostalCode),
                request.Description,
                ContactInfo.Create(
                    request.ContactInfo.PhoneNumber,
                    request.ContactInfo.Email),
                OpeningHours.Create(
                    request.OpeningHours.OpenTime,
                    request.OpeningHours.CloseTime)
                );

            return _restaurantRepository.Add(restaurant);
        }
    }
}