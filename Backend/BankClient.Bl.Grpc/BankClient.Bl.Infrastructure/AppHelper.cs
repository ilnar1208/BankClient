using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankClient.Bl.Infrastructure;

/// <summary>Помощник настройки приложения.</summary>
public static class AppHelper
{
    /// <summary>Добавить инфраструктуру.</summary>
    public static void AddBlInfrastructure(
        this IServiceCollection services,
        IConfigurationSection jwtOptionsConfSection
        )
    {
        services.Configure<JwtOptions>(jwtOptionsConfSection);
        services.AddSingleton<IPasswordService, PasswordService>();
        services.AddSingleton<IJwtProvider, JwtProvider>();
    }
}
