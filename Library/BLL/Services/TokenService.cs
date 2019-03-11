using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BLL.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSecurityToken _jwt;

        public TokenService(IConfiguration configuration)
        {
            var configuration1 = configuration;

            var issuer = configuration1["JwtTokenConfiguration:Issuer"];
            var audience = configuration1["JwtTokenConfiguration:Audience"];
            var secretKey = configuration1["JwtTokenConfiguration:SecretKey"];
            var lifetime = configuration1["JwtTokenConfiguration:Lifetime"];

            var currentTime = DateTime.UtcNow;
            _jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                notBefore: currentTime,
                expires: currentTime.Add(TimeSpan.FromMinutes(int.Parse(lifetime))),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(secretKey)),
                    SecurityAlgorithms.HmacSha256)
            );
        }

        public string GetEncodedJwtToken()
        {
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(_jwt);

            return encodedToken;
        }
    }
}
