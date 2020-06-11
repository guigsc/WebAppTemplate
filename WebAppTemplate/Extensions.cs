using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTemplate.Application.User;
using WebAppTemplate.CrossCutting.Results;
using WebAppTemplate.Infra.Auth;
using WebAppTemplate.Infra.User;

namespace WebAppTemplate
{
    public static class Extensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserApplicationService, UserApplicationService>();
            services.AddSingleton<IAuthProvider, AuthProvider>();
            services.AddSingleton<IUserProvider, UserProvider>();
            services.AddSingleton<IResult, Result>();
            services.AddSingleton(typeof(IDataResult<>), typeof(DataResult<>));
        }

        public static void AddAuthenticationService(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => 
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });
        }
    }
}
