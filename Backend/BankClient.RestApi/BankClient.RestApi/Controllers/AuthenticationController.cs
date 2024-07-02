using Microsoft.AspNetCore.Mvc;

using BankClient.Bl.Shared;

namespace BankClient.RestApi.Controllers;

/// <summary>Аутентификация. Контроллер.</summary>
[ApiController]
[Route("authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _service;

    public AuthenticationController(IAuthenticationService service)
    {
        _service = service;
    }

    /// <summary>
    /// Авторизация.
    /// </summary>
    /// <param name="loginRequest">Запрос на авторизацию.</param>
    /// <returns>Ответ на авторизацию.</returns>
    [HttpGet("login/{login}/{password}")]
    public async Task<string> LoginAsync(
        string login,
        string password) 
    {
        return await _service.LoginAsync(login, password);
    }

    /// <summary>Запрос на авторизацию.</summary>
    public class LoginRequest
    {
        /// <summary>Логин.</summary>
        public string? Login { get; set; }
        /// <summary>Пароль.</summary>
        public string? Password { get; set; }
    }
}
