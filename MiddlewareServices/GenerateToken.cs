using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MiddlewareServices
{
    public class GenerateToken
    {        
        public string Generate(string key, string issu, string aud, string email, string role, int userId)
        {
                                 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {                
                new Claim("Email", email),
                new Claim("Roles", role),
                new Claim("UserId", userId.ToString())
            };

            var Sectoken = new JwtSecurityToken(issu, aud, claims,
              expires: DateTime.Now.AddMinutes(20),
              signingCredentials: credential);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return token;
        }

    }
}
