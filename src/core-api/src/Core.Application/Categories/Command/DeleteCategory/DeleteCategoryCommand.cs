using Core.Domain.CategoryAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Categories.Command.DeleteCategory
{
    public record DeleteCategoryCommand(
        CategoryId CategoryId) : IRequest<ErrorOr<Deleted>>;
}