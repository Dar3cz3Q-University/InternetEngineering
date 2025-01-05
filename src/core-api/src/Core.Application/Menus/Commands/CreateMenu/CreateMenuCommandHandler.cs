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

        public CreateMenuCommandHandler(
            IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(
            CreateMenuCommand request,
            CancellationToken cancellationToken)
        {
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

            var result = await _menuRepository.AddAsync(menu);

            // TODO: Check for more specific error
            if (result.IsError)
            {
                throw new ApplicationException("Failed to add menu to database.");
            }

            return menu;
        }
    }
}