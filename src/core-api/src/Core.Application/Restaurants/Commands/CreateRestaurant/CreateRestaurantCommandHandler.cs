using Core.Application.Common.Config;
using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Application.Restaurants.Common;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler :
        IRequestHandler<CreateRestaurantCommand, ErrorOr<RestaurantDTO>>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IAddressService _addressService;
        private readonly IImageSaver _saver;

        public CreateRestaurantCommandHandler(
            IRestaurantRepository restaurantRepository,
            IAddressService addressService,
            IImageSaver saver)
        {
            _restaurantRepository = restaurantRepository;
            _addressService = addressService;
            _saver = saver;
        }

        public async Task<ErrorOr<RestaurantDTO>> Handle(
            CreateRestaurantCommand request,
            CancellationToken cancellationToken)
        {
            var imageUrl = await _saver.Save(request.Image, StaticFilesSettings.RESTAURANTS, cancellationToken);

            var address = await _addressService.CreateAddressAsync(request.Location);

            var restaurant = Restaurant.Create(
                request.Name,
                imageUrl,
                address,
                request.Description,
                request.Categories,
                ContactInfo.Create(
                    request.ContactInfo.PhoneNumber,
                    request.ContactInfo.Email),
                OpeningHours.Create(
                    request.OpeningHours.OpenTime,
                    request.OpeningHours.CloseTime));

            var result = await _restaurantRepository.AddAsync(restaurant);

            if (result.IsError)
                throw new ApplicationException("Failed to add restaurant to database.");

            return new RestaurantDTO(restaurant, null);
        }
    }
}