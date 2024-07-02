using Microsoft.AspNetCore.Mvc;

using BankClient.Bl.Shared;

namespace BankClient.RestApi.Controllers;

/// <summary>Пользователь. Контроллер.</summary>
[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    /// <summary>
    /// Получить пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Пользователь.</returns>
    [HttpGet("{id}")]
    public async Task<UserDto?> GetAsync(long id)
    {   
        return await _service.GetUserByIdAsync(id);
    }
}
