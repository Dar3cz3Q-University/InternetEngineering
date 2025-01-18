using Core.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Categories.Query.GetCategories
{
    public record GetCategoriesQuery() : IRequest<ErrorOr<List<Category>>>;
}
