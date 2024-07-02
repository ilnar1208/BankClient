using BankClient.Bl.Shared;
using Grpc.Core;

namespace BankClient.Bl.Grpc.Services;

/// <summary>Аутентификация. Сервис GRPC.</summary>
public class AuthenticationService : Authentication.AuthenticationBase
{
    private readonly IAuthenticationService _service;
    public AuthenticationService(IAuthenticationService service)
    {
        _service = service;
    }

    /// <summary>
    /// Авторизация.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="context">Контекст.</param>
    /// <returns>Ответ.</returns>
    public override async Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
    {
        var data = await _service.LoginAsync(request.PhoneNumber, request.Password);

        var result = new LoginResponse()
        {
            Token = data
        };

        return result;
    }
}
