using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CariBengkel.Domain.Cores;
using CariBengkel.Repository.Entity.Custom;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CariBengkel.Domain.Services {
    public class TokenServices : ITokenServices {
        private readonly TokenSetting _tokenSetting;

        public TokenServices (IOptions<TokenSetting> tokenSetting) {
            _tokenSetting = tokenSetting.Value;
        }

        public string CreateToken (string username, string roleId) {
            string token = string.Empty;

            var claim = new [] {
                new Claim (ClaimTypes.Name, username),
                new Claim (ClaimTypes.Role, roleId)
            };

            var key = new SymmetricSecurityKey (Encoding.ASCII.GetBytes (_tokenSetting.Secret));
            var credential = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken (
                _tokenSetting.Issuer,
                _tokenSetting.Audience,
                claim,
                expires : DateTime.Now.AddMinutes (_tokenSetting.AccessExpiration),
                signingCredentials : credential
            );

            token = new JwtSecurityTokenHandler ().WriteToken (jwtToken);

            return token;
        }
    }
}