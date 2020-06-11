using System.Collections.Generic;
using System.Security.Claims;
using WebAppTemplate.CrossCutting.Results;
using WebAppTemplate.Model.Auth;

namespace WebAppTemplate.Infra.User
{
    public interface IUserProvider
    {
        IDataResult<List<Claim>> GetUserClaims(SignInModel signInModel);
    }
}
