using System.Collections.Generic;
using System.Security.Claims;
using WebAppTemplate.CrossCutting.Results;
using WebAppTemplate.Model.Auth;

namespace WebAppTemplate.Infra.User
{
    public class UserProvider : IUserProvider
    {
        public IDataResult<List<Claim>> GetUserClaims(SignInModel signInModel)
        {
            // get user from DB

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInModel.Username),
            };

            return DataResult<List<Claim>>.Success(claims);
        }
    }
}
