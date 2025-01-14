using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Menu.Commands.CreateMenuSection
{
    public record CreateMenuSectionCommand(
        RestaurantId RestaurantId,
        string Name,
        string Description) : IRequest<ErrorOr<MenuSection>>;
}