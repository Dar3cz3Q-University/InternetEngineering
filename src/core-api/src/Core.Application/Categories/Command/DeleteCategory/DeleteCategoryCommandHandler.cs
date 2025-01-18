using Core.Application.Common.Interfaces.Persistance;
using ErrorOr;
using MediatR;

namespace Core.Application.Categories.Command.DeleteCategory
{
    internal class DeleteCategoryCommandHandler
        : IRequestHandler<DeleteCategoryCommand, ErrorOr<Deleted>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.DeleteByIdAsync(request.CategoryId);

            if (result.IsError)
                throw new ApplicationException("Failed to remove category from database.");

            return Result.Deleted;
        }
    }
}