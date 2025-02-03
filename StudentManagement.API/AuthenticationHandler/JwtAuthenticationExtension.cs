using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace StudentManagement.API.AuthenticationHandler
{
    public static class JwtAuthenticationExtension
    {
        public static void AddJwtAuthentication(this IServiceCollection services, string issuer, string audience, string secret, string UserJwt_Key, string UserJwt_audience)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = audience,
                        ValidIssuer = issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
