using Core.Application.Authentication.Commands.Register;
using Core.Application.Authentication.Common;
using Core.Application.Authentication.Queries.Login;
using Core.Contracts.Authentication.Request;
using Core.Contracts.Authentication.Response;
using Core.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationDTO> authResult = await _mediator.Send(command);

            return authResult.Match(
                r => Ok(_mapper.Map<AuthenticationResponse>(r)),
                e => Problem(e)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationDTO> authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                r => Ok(_mapper.Map<AuthenticationResponse>(r)),
                e => Problem(e)
            );
        }
    }
}