using Core.Application.Orders.Common;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetOrdersReadyToCollect
{
    public record GetOrdersReadyToCollectQuery(
        double? Latitude,
        double? Longitude) : IRequest<ErrorOr<List<OrderWithAddressesDTO>>>;
}
