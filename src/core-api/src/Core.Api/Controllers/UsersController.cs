using Core.Application.Users.Commands.AddAddress;
using Core.Application.Users.Commands.UpdateMaxSearchDistance;
using Core.Application.Users.Queries.GetUser;
using Core.Contracts.Authentication.Response;
using Core.Contracts.User.Request;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("users")]
    public class UsersController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UsersController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetUser()
        {
            var query = new GetUserQuery();

            var result = await _mediator.Send(query);

            return result.Match(
                r => Ok(_mapper.Map<AuthenticationResponse>(r)),
                e => Problem(e)
            );
        }

        [HttpPost("address")]
        public async Task<IActionResult> AddAddress(AddAddressRequest request)
        {
            var command = _mapper.Map<AddAddressCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                r => NoContent(),
                e => Problem(e)
            );
        }

        [HttpPatch("max-search-distance")]
        public async Task<IActionResult> UpdateMaxSearchDistance(UpdateMaxSearchDistanceRequest request)
        {
            var command = _mapper.Map<UpdateMaxSearchDistanceCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                r => NoContent(),
                e => Problem(e)
            );
        }
    }
}