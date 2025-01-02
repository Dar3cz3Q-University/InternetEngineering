using Core.Application.Common.Interfaces.Validation;
using Core.Domain.MenuAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Commands.DeleteMenu
{
    public record DeleteMenuCommand(
        MenuId MenuId) : IRequest<ErrorOr<Unit>>, IRequireMenuValidation;
}
