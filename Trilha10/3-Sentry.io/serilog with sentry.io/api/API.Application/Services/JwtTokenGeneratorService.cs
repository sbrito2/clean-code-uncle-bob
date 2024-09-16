using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Application.Services
{
    public class JwtTokenGeneratorService
    {
        private readonly IConfiguration configuration;
        
        public JwtTokenGeneratorService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            int profileId = user.ProfileId;

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Name", user.Name.ToString(), ClaimTypes.Name),
                new Claim("UserId", user.Id.ToString(), ClaimValueTypes.Integer),
                new Claim("ProfileId", profileId.ToString(), ClaimValueTypes.Integer)
            }; 
            
            return this.GenerateJWTToken(claims);
        }

        public string GenerateJWTToken(List<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["TokenConfigurations:Key"]); 
            var sgningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key);
            

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(sgningKey, SecurityAlgorithms.HmacSha256),
                Expires  = DateTime.Now.Add(TimeSpan.FromDays(2)),
                NotBefore = DateTime.Now,
                Subject = claimsIdentity,
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
