using Core.Domain.OrderAggregate.ValueObjects;
using ErrorOr;

namespace Core.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Order
        {
            public static Error NotFound(OrderId id) => Error.NotFound(
                code: "Order.NotFound",
                description: "Order with ID: '" + id.Value.ToString() + "' doesn't exists.");

            public static Error NotFound() => Error.NotFound(
                code: "Order.ItemsNotFound",
                description: "Some of the items have invalid ID.");
        }
    }
}