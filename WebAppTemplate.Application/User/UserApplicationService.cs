using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppTemplate.CrossCutting.Results;
using WebAppTemplate.Infra.Auth;
using WebAppTemplate.Infra.User;
using WebAppTemplate.Model.Auth;

namespace WebAppTemplate.Application.User
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IAuthProvider _authProvider;
        private readonly IUserProvider _userProvider;
        private readonly IHttpClientFactory _httpClient;

        public UserApplicationService(IAuthProvider authProvider, IUserProvider userProvider, IHttpClientFactory httpClient)
        {
            _authProvider = authProvider;
            _userProvider = userProvider;
            _httpClient = httpClient;
        }

        public async Task<IDataResult<TokenModel>> SignInAsync(SignInModel signInModel)
        {
            var validation = new SignInModelValidator().Validate(signInModel);
            if (validation.Failed)
            {
                return DataResult<TokenModel>.Fail(validation.Message);
            }

            // check if user exists in database
            // if so, generate a token for it

            var claims = _userProvider.GetUserClaims(signInModel);
            if (claims.Failed)
            {
                return DataResult<TokenModel>.Fail(claims.Message);
            }

            var token = _authProvider.GenerateToken(claims.Data);

            return await Task.Run(() =>
            {
                return token;
            });
        }
    }
}
