using Core.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Categories.Command.CreateCategory
{
    public record CreateCategoryCommand(
        string Name,
        IFormFile Image) : IRequest<ErrorOr<Category>>;
}