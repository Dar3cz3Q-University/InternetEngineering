﻿using Core.Application.Authentication.Commands.Register;
using Core.Application.Authentication.Common;
using Core.Application.Authentication.Queries.Login;
using Core.Contracts.Authentication.Request;
using Core.Contracts.Authentication.Response;
using Core.Domain.Common.Errors;
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

            var authResult = await _mediator.Send(command);

            return authResult.Match(
                r =>
                {
                    SetCookies(r);
                    return Ok(_mapper.Map<AuthenticationResponse>(r));
                },
                e => Problem(e)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

            return authResult.Match(
                r =>
                {
                    SetCookies(r);
                    return Ok(_mapper.Map<AuthenticationResponse>(r));
                },
                e => Problem(e)
            );
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("JwtToken");
            Response.Cookies.Delete("IsLoggedIn");
            return NoContent();
        }

        private void SetCookies(AuthenticationDTO authentication)
        {
            Response.Cookies.Append("JwtToken", authentication.Token, new CookieOptions()
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = authentication.TokenExpiryDate
            });

            Response.Cookies.Append("IsLoggedIn", "1", new CookieOptions()
            {
                Expires = authentication.TokenExpiryDate
            });
        }
    }
}