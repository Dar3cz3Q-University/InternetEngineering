using Core.Application.Common.Config;
using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.Common.ValueObjects;
using Core.Domain.RestaurantAggregate.Entities;
using ErrorOr;
using MediatR;

namespace Core.Application.Menu.Commands.CreateMenuItem
{
    public class CreateMenuItemCommandHandler
        : IRequestHandler<CreateMenuItemCommand, ErrorOr<MenuItem>>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IImageSaver _imageSaver;

        public CreateMenuItemCommandHandler(
            IRestaurantRepository restaurantRepository,
            IImageSaver imageSaver)
        {
            _restaurantRepository = restaurantRepository;
            _imageSaver = imageSaver;
        }

        public async Task<ErrorOr<MenuItem>> Handle(
            CreateMenuItemCommand request,
            CancellationToken cancellationToken)
        {
            var restaurantResult = await _restaurantRepository.GetByIdAsync(request.RestaurantId);

            if (restaurantResult.IsError)
                return restaurantResult.Errors;

            var imageUrl = await _imageSaver.Save(request.Image, StaticFilesSettings.MENU_ITEMS, cancellationToken);

            var restaurant = restaurantResult.Value;

            var item = MenuItem.Create(
                request.Name,
                imageUrl,
                request.Description,
                Money.Create(
                    request.Price.Amount,
                    request.Price.Currency));

            restaurant.AddMenuItem(request.MenuSectionId, item);

            await _restaurantRepository.UpdateAsync(restaurant);

            return item;
        }
    }
}