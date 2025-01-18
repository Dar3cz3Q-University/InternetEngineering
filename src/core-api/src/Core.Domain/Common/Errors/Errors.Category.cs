using Core.Domain.CategoryAggregate.ValueObjects;
using ErrorOr;

namespace Core.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Category
        {
            public static Error NotFound(CategoryId id) => Error.NotFound(
                code: "Category.NotFound",
                description: "Category with ID: '" + id.Value.ToString() + "' doesn't exists.");
        }
    }
}