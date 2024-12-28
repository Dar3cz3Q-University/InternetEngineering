using Core.Application.Restaurants.Commands.CreateRestaurant;
using Core.Application.Restaurants.Queries.GetRestaurantById;
using Core.Application.Restaurants.Queries.GetRestaurants;
using Core.Contracts.Restaurant.Request;
using Core.Contracts.Restaurant.Response;
using MapsterMapper;
using MediatR;
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
        public async Task<IActionResult> GetAll()
        {
            var query = new GetRestaurantsQuery();

            var restaurants = await _mediator.Send(query);

            return restaurants.Match(
                r => Ok(r.ConvertAll(r => _mapper.Map<RestaurantResponse>(r))),
                e => Problem(e));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = _mapper.Map<GetRestaurantByIdQuery>(id);

            var restaurant = await _mediator.Send(query);

            return restaurant.Match(
                r => Ok(_mapper.Map<RestaurantResponse>(r)),
                e => Problem(e));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRestaurantRequest request)
        {
            var command = _mapper.Map<CreateRestaurantCommand>(request);

            var createRestaurant = await _mediator.Send(command);

            return createRestaurant.Match(
                r => Ok(_mapper.Map<RestaurantResponse>(r)),
                e => Problem(e));
        }

        [HttpPut]
        public async Task<IActionResult> Edit()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }
    }
}
