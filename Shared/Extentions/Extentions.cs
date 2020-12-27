using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Extentions
{
    public static class Extentions
    {
        public static void AddJwt(this IServiceCollection services, string key)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options => {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                   .GetBytes(key)),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });
        }
    }
}
