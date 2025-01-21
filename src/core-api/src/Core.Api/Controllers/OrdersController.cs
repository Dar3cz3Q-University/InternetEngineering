using Core.Application.Orders.Commands.CreateOrder;
using Core.Application.Orders.Commands.DeleteOrder;
using Core.Application.Orders.Commands.DeliverOrder;
using Core.Application.Orders.Commands.TakeOrder;
using Core.Application.Orders.Queries.GetActiveOrderForCourier;
using Core.Application.Orders.Queries.GetOrder;
using Core.Application.Orders.Queries.GetOrders;
using Core.Application.Orders.Queries.GetOrdersReadyToCollect;
using Core.Contracts.Order.Request;
using Core.Contracts.Order.Response;
using Core.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("ready-for-collection")]
        [Authorize(Roles = "Admin,Courier")]
        public async Task<IActionResult> GetAllForCollection(
            [FromQuery] GetOrdersReadyToCollectRequest request)
        {
            var query = _mapper.Map<GetOrdersReadyToCollectQuery>(request);

            var orders = await _mediator.Send(query);

            return orders.Match(
                o => Ok(o.ConvertAll(o => _mapper.Map<OrderReadyToCollectResponse>(o))),
                e => Problem(e));
        }

        [HttpGet("active")]
        [Authorize(Roles = "Courier")]
        public async Task<IActionResult> GetActiveForCourier(
            [FromQuery] GetActiveOrderForCourier request)
        {
            var query = _mapper.Map<GetActiveOrderForCourierQuery>(request);

            var orders = await _mediator.Send(query);

            return orders.Match(
                o => Ok(_mapper.Map<ActiveOrderForCourierResponse>(o)),
                e => Problem(e));
        }

        [HttpPatch("{id:guid}/take")]
        [Authorize(Roles = "Courier")]
        public async Task<IActionResult> TakeOrder(Guid id)
        {
            var command = _mapper.Map<TakeOrderCommand>(id);

            var result = await _mediator.Send(command);

            return result.Match(
                r => NoContent(),
                e => Problem(e));
        }

        [HttpPatch("deliver")]
        [Authorize(Roles = "Courier")]
        public async Task<IActionResult> DeliverOrder()
        {
            var command = new DeliverOrderCommand();

            var result = await _mediator.Send(command);

            return result.Match(
                r => NoContent(),
                e => Problem(e));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = _mapper.Map<GetOrderQuery>(id);

            var orderResult = await _mediator.Send(query);

            if (orderResult.IsError && orderResult.FirstError == Errors.Authentication.InsufficientPermissions)
            {
                return Problem(statusCode: StatusCodes.Status403Forbidden, title: orderResult.FirstError.Description);
            }

            return orderResult.Match(
                o => Ok(_mapper.Map<OrderResponseWithDetails>(o)),
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

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update()
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Admin")]
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