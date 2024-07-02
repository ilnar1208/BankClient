using BankClient.Bl.Grpc.Client;
using Grpc.Core;

namespace BankClient.RestApi;

/// <summary>Помощник конфигурации.</summary>
public class ConfigureHelper
{
    /// <summary>Конфигурация бизнес логики. GRPC.</summary>
    public static void ConfigureBlGrpc(WebApplicationBuilder builder)
    {
        var blGrpcServiceSettings = builder.Configuration.GetSection("BlGrpcServiceSettings").Get<BlGrpcServiceSettings>()!;
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddTransient<AuthHeadersInterceptor>();

        AddGrpcClient<Authentication.AuthenticationClient>(builder, blGrpcServiceSettings);
        AddGrpcClient<User.UserClient>(builder, blGrpcServiceSettings);
        AddGrpcClient<UserAccount.UserAccountClient>(builder, blGrpcServiceSettings);

        builder.Services.AddBlGrpc();
    }

    private static void AddGrpcClient<TClient>(WebApplicationBuilder builder, BlGrpcServiceSettings settings)
        where TClient : ClientBase
    {
        var httpClientBuilder = builder.Services.AddGrpcClient<TClient>(o => { o.Address = new Uri(settings.Address); });
        httpClientBuilder.AddInterceptor<AuthHeadersInterceptor>();
    }
}
