using Microsoft.EntityFrameworkCore;

using BankClient.Dal.Ef;
using BankClient.Bl.Infrastructure;
using BankClient.Bl.Grpc.Extensions;

namespace BankClient.Bl.Grpc;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder);

        var app = builder.Build();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapGrpcService<Services.AuthenticationService>();
        app.MapGrpcService<Services.UserService>().RequireAuthorization();
        app.MapGrpcService<Services.UserAccountService>().RequireAuthorization();

        app.Run();
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("BankClientDbConnection");
        builder.Services.AddDalEf(options =>
            options
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention());

        var jwtOptionConfSection = builder.Configuration.GetSection("JwtOptions");
        builder.Services.AddBlInfrastructure(jwtOptionConfSection);
        builder.Services.AddBl();
        builder.Services.AddAppAuthentication(jwtOptionConfSection);
        builder.Services.AddGrpc();
    }
}