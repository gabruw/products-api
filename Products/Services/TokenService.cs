using Domain.Entity;
using Domain.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Products.Services
{
    public static class TokenService
    {
        public static string GenerateToken(Customer customer)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JWT.GetInstance().Secret);

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.SerialNumber, customer.Cpf),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
