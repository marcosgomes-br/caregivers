using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Caregivers.Application.DTOs;
using Caregivers.Domains;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Caregivers.Application.Helpers
{
    public static class Token
    {
        public static TokenDto Generate(User user, IConfiguration configuration)
        {
            var claims = new[]
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("user", user.Email),
                new Claim("jwt", Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);
            return new TokenDto
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            };
        }
    }
}