﻿using Core.Application.Common.Interfaces.Authentication;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.UserAggregate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Infrastructure.Authentication.Token
{
    public class JwtTokenGenerator(
        IDateTimeProvider dateTimeProvider,
        IOptions<JwtSettings> jwtOptions) : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
        private readonly JwtSettings _jwtSettings = jwtOptions.Value;

        public (string, DateTime) GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var expires = _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes);

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: expires,
                claims: claims,
                signingCredentials: signingCredentials);

            return (new JwtSecurityTokenHandler().WriteToken(securityToken), expires);
        }
    }
}