using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Users.Results;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Blog.Application.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Blog.Persistence.Concrete
{
    public class JwtService(UserManager<AppUser> userManager , IOptions<JwtTokenOptions> token) : IJwtService
    {
        private readonly JwtTokenOptions jwtTokenOptions = token.Value;
        public async Task<GetLoginResponse> GenerateTokenAsync(GetUserQueryResult result)
        {
            var user = await userManager.FindByNameAsync(result.UserName);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenOptions.Key));
            var dateTimeNow = DateTime.UtcNow;

            List<Claim> claims = new()
            {
                new(JwtRegisteredClaimNames.Name,user.UserName),
                new(JwtRegisteredClaimNames.Sub,user.Id),
                new(JwtRegisteredClaimNames.Email,user.Email),
                new("FullName",string.Join(" ",user.FirstName,user.LastName))
            };
            JwtSecurityToken jwtSecurityToken = new(
                issuer: jwtTokenOptions.Issuer,
                audience: jwtTokenOptions.Audience,
                claims: claims,
                notBefore: dateTimeNow,
                expires: dateTimeNow.AddMinutes(jwtTokenOptions.ExpireInMinutes),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

            GetLoginResponse response = new();
            response.Token=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Expiration=dateTimeNow.AddMinutes(jwtTokenOptions.ExpireInMinutes);
            return response;
        }
    }
}
