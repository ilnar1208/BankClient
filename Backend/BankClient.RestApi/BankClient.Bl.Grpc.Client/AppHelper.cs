using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BankClient.Bl.Shared;
using Grpc.Core;

namespace BankClient.Bl.Grpc.Client;

/// <summary>Помощник для настройки приложения.</summary>
public static class AppHelper
{
    /// <summary>Добавить бизнес-логику, которая доступна по GRPC.</summary>
    public static void AddBlGrpc(
        this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserAccountService, UserAccountService>();
    }
}
