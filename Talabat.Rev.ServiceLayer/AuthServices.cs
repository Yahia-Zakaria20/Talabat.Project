using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites.IdentityData;
using Talabat.Rev.CoreLayer.ServiceLayer.Contract;

namespace Talabat.Rev.ServiceLayer
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _configuration;

        public AuthServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateTokenAsync(AppUser user, UserManager<AppUser> userManager)
        {

            
            //Private Claims 

            var Claims = new List<Claim>() 
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName,user.UserName),
            };

            var Rols = await userManager.GetRolesAsync(user);

            foreach (var role in Rols) 
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //Secretkey
            var SecKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));

            var TokenObj = new JwtSecurityToken(
                //Register Claims
                audience: _configuration["Jwt:Audience"],
                issuer: _configuration["Jwt:Issuer"],
                expires: DateTime.UtcNow.AddDays(double.Parse(_configuration["Jwt:Expire"])),
                claims: Claims,
                signingCredentials: new SigningCredentials(SecKey,SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(TokenObj);
        }
    }
}
