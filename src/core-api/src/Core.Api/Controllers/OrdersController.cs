using Core.Application.Orders.Commands.CreateOrder;
using Core.Application.Orders.Commands.DeleteOrder;
using Core.Application.Orders.Commands.UpdateOrder;
using Core.Application.Orders.Queries.GetOrder;
using Core.Application.Orders.Queries.GetOrders;
using Core.Contracts.Order.Request;
using Core.Contracts.Order.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("orders")]
    public class OrdersController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public OrdersController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetOrdersQuery();

            var orders = await _mediator.Send(query);

            return orders.Match(
                o => Ok(o.ConvertAll(o => _mapper.Map<OrderResponse>(o))),
                e => Problem(e));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = _mapper.Map<GetOrderQuery>(id);

            var order = await _mediator.Send(query);

            return order.Match(
                o => Ok(_mapper.Map<OrderResponse>(o)),
                e => Problem(e));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var command = _mapper.Map<CreateOrderCommand>(request);

            var createOrder = await _mediator.Send(command);

            return createOrder.Match(
                o => Ok(_mapper.Map<OrderResponse>(o)),
                e => Problem(e));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateOrderRequest request)
        {
            var command = _mapper.Map<UpdateOrderCommand>((id, request));

            var updateOrder = await _mediator.Send(command);

            return updateOrder.Match(
                o => Ok(_mapper.Map<OrderResponse>(o)),
                e => Problem(e));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = _mapper.Map<DeleteOrderCommand>(id);

            var response = await _mediator.Send(command);

            return response.Match(
                _ => NoContent(),
                e => Problem(e));
        }
    }
}