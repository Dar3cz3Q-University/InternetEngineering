using Core.Application.Categories.Command.CreateCategory;
using Core.Application.Categories.Command.DeleteCategory;
using Core.Contracts.Category.Request;
using Core.Contracts.Category.Response;
using Core.Domain.CategoryAggregate;
using Core.Domain.CategoryAggregate.ValueObjects;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class CategoryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //
            // Response
            //

            config.NewConfig<Category, CategoryResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.ImageUrl, src => $"http://192.168.0.5:8080/{src.ImageUrl}");

            //
            // Create
            //

            config.ForType<CreateCategoryRequest, CreateCategoryCommand>()
                .Map(dest => dest.Image, src => src.Image)
                .PreserveReference(true);

            config.NewConfig<Guid, CategoryId>()
                .MapWith(guid => CategoryId.Create(guid));

            //
            // Delete
            //

            config.NewConfig<Guid, DeleteCategoryCommand>()
                .Map(dest => dest.CategoryId, src => CategoryId.Create(src));

            //
            // Update
            //



            //
            // Get
            //



            //
            // Utils
            //

            config.NewConfig<CategoryId, CategoryId>()
                .MapWith(src => src);
        }
    }
}
