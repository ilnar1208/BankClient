using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankClient.Dal.Ef;

/// <summary>Помощник настройки приложения.</summary>
public static class AppHelper
{
    /// <summary>Добавить слой данных. Entity Framework.</summary>
    public static void AddDalEf(this IServiceCollection services,
            Action<DbContextOptionsBuilder>? optionsAction = null,
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
            ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
    {
        ConfigureMapping();

        services.AddDbContext<BankClientDataContext>(optionsAction, contextLifetime, optionsLifetime);
        AddRepositories(services, contextLifetime);
    }

    private static void AddRepositories(IServiceCollection services, ServiceLifetime contextLifetime)
    {
        services.AddByLifetime<IUserRepository, UserRepository>(contextLifetime);
        services.AddByLifetime<IUserAccountRepository, UserAccountRepository>(contextLifetime);
    }

    public static void AddByLifetime<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime)
            where TService : class
            where TImplementation : class, TService
    {
        services.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifetime));
    }

    private static void ConfigureMapping()
    {
        TypeAdapterConfig<UserAccount, UserAccountDal>.NewConfig();
        TypeAdapterConfig<UserAccount, UserAccountDal>.NewConfig()
            .Map(dest => dest.AccountTypeId, src => src.AccountType.Id)
            .Map(dest => dest.AccountTypeName, src => src.AccountType.Name);
    }
}
