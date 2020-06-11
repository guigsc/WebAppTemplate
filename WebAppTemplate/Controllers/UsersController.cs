using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAppTemplate.Application.User;
using WebAppTemplate.Model.Auth;

namespace WebAppTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;
        public UsersController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(SignInModel signInModel)
        {
            return Ok(await _userApplicationService.SignInAsync(signInModel));
        }
    }
}