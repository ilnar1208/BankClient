using Microsoft.AspNetCore.Mvc;

using BankClient.Bl.Shared;

namespace BankClient.RestApi.Controllers;

/// <summary>��������������. ����������.</summary>
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
    /// �����������.
    /// </summary>
    /// <param name="loginRequest">������ �� �����������.</param>
    /// <returns>����� �� �����������.</returns>
    [HttpGet("login/{login}/{password}")]
    public async Task<string> LoginAsync(
        string login,
        string password) 
    {
        return await _service.LoginAsync(login, password);
    }

    /// <summary>������ �� �����������.</summary>
    public class LoginRequest
    {
        /// <summary>�����.</summary>
        public string? Login { get; set; }
        /// <summary>������.</summary>
        public string? Password { get; set; }
    }
}
