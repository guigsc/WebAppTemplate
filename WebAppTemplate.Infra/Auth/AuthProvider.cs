using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAppTemplate.CrossCutting.Config;
using WebAppTemplate.CrossCutting.Results;
using WebAppTemplate.Model.Auth;

namespace WebAppTemplate.Infra.Auth
{
    public class AuthProvider : IAuthProvider
    {
        private readonly JwtSettings _jwtSettings;
        public AuthProvider(IOptions<JwtSettings> configurationOptions)
        {
            _jwtSettings = configurationOptions.Value;
        }

        public IDataResult<TokenModel> GenerateToken(List<Claim> claims)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
            
                var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

                var expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_jwtSettings.Expires));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = expires,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                var tokenModel = new TokenModel
                {
                    Token = tokenHandler.WriteToken(token),
                    RefreshToken = "asdashd87ysa8dh98ydshu",
                    Expires = expires.ToString("yyyy-MM-dd hh:mm:ss")
                };

                return DataResult<TokenModel>.Success(tokenModel);
            }
            catch (Exception ex)
            {
                return DataResult<TokenModel>.Fail(ex.Message);
            }
        }
    }
}
