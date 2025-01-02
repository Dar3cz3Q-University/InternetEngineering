using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.ValueObjects;
using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Commands.CreateMenu
{
    internal class CreateMenuCommandHandler :
        IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IOrderRepository _restaurantRepository;

        public CreateMenuCommandHandler(
            IMenuRepository menuRepository,
            IOrderRepository restaurantRepository)
        {
            _menuRepository = menuRepository;
            _restaurantRepository = restaurantRepository;
        }

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Menu>> Handle(
            CreateMenuCommand request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var menu = Menu.Create(
                request.Name,
                request.Description,
                request.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.Create(
                        item.Name,
                        item.Description,
                        Money.Create(
                            item.Price.Amount,
                            item.Price.Currency))))),
                request.RestaurantId);

            return _menuRepository.Add(menu);
        }
    }
}