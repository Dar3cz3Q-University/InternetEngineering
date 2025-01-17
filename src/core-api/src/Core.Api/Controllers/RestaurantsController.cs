using Core.Application.Restaurants.Commands.CreateRestaurant;
using Core.Application.Restaurants.Commands.DeleteRestaurant;
using Core.Application.Restaurants.Queries.GetRestaurant;
using Core.Application.Restaurants.Queries.GetRestaurants;
using Core.Contracts.Restaurant.Request;
using Core.Contracts.Restaurant.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("restaurants")]
    public class RestaurantsController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public RestaurantsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] double? latitude,
            [FromQuery] double? longitude)
        {
            var query = _mapper.Map<GetRestaurantsQuery>((latitude, longitude));

            var restaurants = await _mediator.Send(query);

            return restaurants.Match(
                r => Ok(r.ConvertAll(r => _mapper.Map<RestaurantResponse>(r))),
                e => Problem(e));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(
            Guid id,
            [FromQuery] double? latitude,
            [FromQuery] double? longitude)
        {
            var query = _mapper.Map<GetRestaurantQuery>((id, latitude, longitude));

            var restaurant = await _mediator.Send(query);

            return restaurant.Match(
                r => Ok(_mapper.Map<RestaurantResponseWithDetails>(r)),
                e => Problem(e));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateRestaurantRequest request)
        {
            var command = _mapper.Map<CreateRestaurantCommand>(request);

            var createRestaurant = await _mediator.Send(command);

            return createRestaurant.Match(
                r => Ok(_mapper.Map<RestaurantResponseWithDetails>(r)),
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
            var command = _mapper.Map<DeleteRestaurantCommand>(id);

            var response = await _mediator.Send(command);

            return response.Match(
                _ => NoContent(),
                e => Problem(e));
        }
    }
}