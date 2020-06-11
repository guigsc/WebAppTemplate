using System.Collections.Generic;
using System.Security.Claims;
using WebAppTemplate.CrossCutting.Results;
using WebAppTemplate.Model.Auth;

namespace WebAppTemplate.Infra.Auth
{
    public interface IAuthProvider
    {
        IDataResult<TokenModel> GenerateToken(List<Claim> claims);
    }
}
