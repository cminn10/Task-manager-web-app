using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class JwtService: IJwtService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public JwtService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenSetting:PrivateKey"]));
        }
        
        public string CreateToken(UserResponseModel model)
        {
            var claims = new List<Claim>()
            {
                new Claim("id", model.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, model.Email),
                new Claim("fullname", model.Fullname),
                new Claim("mobileno", model.Mobileno)
            };
            //create identity object to store claims
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);
            
            //pick an hashing algorithm
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.UtcNow.AddDays(_config.GetValue<int>("TokenSetting:Expiration"));

            //Token object: SecurityTokenDescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = creds,
                Issuer = _config["TokenSetting:Issuer"],
                Audience = _config["TokenSetting:Audience"]
            };
            
            //Handler: JwtSecurityTokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}