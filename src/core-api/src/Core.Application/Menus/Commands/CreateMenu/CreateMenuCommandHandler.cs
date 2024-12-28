using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.ValueObjects;
using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.Entities;
using Core.Domain.RestaurantAggregate.ValueObjects;
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
            await Task.CompletedTask;

            // TODO: Validation if parsing to Guid works and check if restaurant exists (maybe DomainEvents)

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
                RestaurantId.Create(Guid.Parse(request.RestaurantId)));

            _menuRepository.Add(menu);

            return menu;
        }
    }
}
