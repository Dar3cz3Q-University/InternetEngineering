using Core.Application.Common.Config;
using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler
        : IRequestHandler<CreateCategoryCommand, ErrorOr<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IImageSaver _imageSaver;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IImageSaver imageSaver)
        {
            _categoryRepository = categoryRepository;
            _imageSaver = imageSaver;
        }

        public async Task<ErrorOr<Category>> Handle(
            CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var imageUrl = await _imageSaver.Save(request.Image, StaticFilesSettings.CATEGORIES, cancellationToken);

            var category = Category.Create(
                request.Name,
                imageUrl);

            var result = await _categoryRepository.AddAsync(category);

            if (result.IsError)
                throw new ApplicationException("Failed to add category to database.");

            return category;
        }
    }
}