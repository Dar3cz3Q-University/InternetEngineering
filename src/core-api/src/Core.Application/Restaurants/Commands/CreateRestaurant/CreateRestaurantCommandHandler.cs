using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
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
        private readonly IAddressService _addressService;

        public CreateRestaurantCommandHandler(
            IRestaurantRepository restaurantRepository,
            IAddressService addressService)
        {
            _restaurantRepository = restaurantRepository;
            _addressService = addressService;
        }

        public async Task<ErrorOr<Restaurant>> Handle(
            CreateRestaurantCommand command,
            CancellationToken cancellationToken)
        {
            var address = await _addressService.CreateAddressAsync(command.Location);

            var restaurant = Restaurant.Create(
                command.Name,
                address,
                command.Description,
                ContactInfo.Create(
                    command.ContactInfo.PhoneNumber,
                    command.ContactInfo.Email),
                OpeningHours.Create(
                    command.OpeningHours.OpenTime,
                    command.OpeningHours.CloseTime));

            var result = await _restaurantRepository.AddAsync(restaurant);

            if (result.IsError)
                throw new ApplicationException("Failed to add restaurant to database.");

            return restaurant;
        }
    }
}