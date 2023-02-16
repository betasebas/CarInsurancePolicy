using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarInsurancePolicyContracts.Requests;
using Microsoft.Extensions.Configuration;
using CarInsurancePolicyDomain.Entities;
using CarInsurancePolicyDomain.Helpers;
using CarInsurancePolicyDomain.Exceptions;
using CarInsurancePolicyContracts.Responses;

namespace CarInsurancePolicyService.Services
{
    public class TokenJwt : ITokenJwt
    {
        private readonly IConfiguration _config;

        public TokenJwt(IConfiguration config)
        {
            _config = config;

        }

        public ResponseGeneric<string> GetJwtAsync(LoginRequest loginRequest)
        {
            var user = GetUser(loginRequest);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _config["Jwt:Inssuer"],
                audience: _config["Jwt:Audience"],
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
            );
                       
            return new ResponseGeneric<string> { Code = 200, Message = "Operacion existosa", Detail = new JwtSecurityTokenHandler().WriteToken(tokeOptions)};
        }

        private User GetUser(LoginRequest loginRequest)
        {
            var user = UserHelper.Users.FirstOrDefault(x => x.UserName.Equals(loginRequest.UserName) && x.Password.Equals(loginRequest.Password));
            if(user == null)
            {
                throw new BadRequestException($"Usuario invalido");
            }

            return user;
        }
    }
}

