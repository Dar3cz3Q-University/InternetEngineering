using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.DeliverOrder
{
    public class DeliverOrderCommand() : IRequest<ErrorOr<Updated>>;
}
