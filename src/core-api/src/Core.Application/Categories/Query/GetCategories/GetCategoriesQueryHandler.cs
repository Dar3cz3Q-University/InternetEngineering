using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Categories.Query.GetCategories
{
    public class GetCategoriesQueryHandler
        : IRequestHandler<GetCategoriesQuery, ErrorOr<List<Category>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<List<Category>>> Handle(
            GetCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAllAsync();
        }
    }
}
