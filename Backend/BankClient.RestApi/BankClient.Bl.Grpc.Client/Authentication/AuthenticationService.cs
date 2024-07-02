using BankClient.Bl.Shared;
using System.Net.Http;

namespace BankClient.Bl.Grpc.Client;

/// <summary>Аутентификация. Сервис.</summary>
public class AuthenticationService : IAuthenticationService
{
    private readonly Authentication.AuthenticationClient _client;

    public AuthenticationService(Authentication.AuthenticationClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Авторизация.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Токен.</returns>
    public async Task<string> LoginAsync(string phoneNumber, string password)
    {
        var reply = await _client.LoginAsync(new LoginRequest { PhoneNumber = phoneNumber, Password = password });

        return reply.Token;
    }
}
