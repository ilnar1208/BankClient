using Mapster;
using Microsoft.Extensions.DependencyInjection;

using BankClient.Dal;
using BankClient.Bl.Shared;

namespace BankClient.Bl;

/// <summary>Помощник настройки приложения.</summary>
public static class AppHelper
{
    /// <summary>Добавить бизнес-логику.</summary>
    public static void AddBl(this IServiceCollection services)
    {
        ConfigureMapping();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserAccountService, UserAccountService>();
    }

    private static void ConfigureMapping()
    {
        TypeAdapterConfig<UserAccountDal, UserAccountDto>.NewConfig();
        TypeAdapterConfig<UserDal, UserDto>.NewConfig();
    }
}
