using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using BankClient.Bl.Infrastructure;

namespace BankClient.Bl.Grpc.Extensions;

/// <summary>Расширение для приложения.</summary>
public static class AppExtensions
{
    /// <summary>Добавить аутентификацию.</summary>
    public static void AddAppAuthentication(this IServiceCollection services,
        IConfigurationSection jwtOptionsConfSection)
    {
        var jwtOptions = jwtOptionsConfSection.Get<JwtOptions>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                };
            });

        services.AddAuthorization();
    }
}
