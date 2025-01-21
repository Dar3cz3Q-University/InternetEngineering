using Core.Application.Orders.Common;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetActiveOrderForCourier
{
    public record GetActiveOrderForCourierQuery(
        double? Latitude,
        double? Longitude) : IRequest<ErrorOr<ActiveOrderForCourierDTO>>;
}
