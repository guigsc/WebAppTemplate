using System.Threading.Tasks;
using WebAppTemplate.CrossCutting.Results;
using WebAppTemplate.Model.Auth;

namespace WebAppTemplate.Application.User
{
    public interface IUserApplicationService
    {
        Task<IDataResult<TokenModel>> SignInAsync(SignInModel signInModel);
    }
}
