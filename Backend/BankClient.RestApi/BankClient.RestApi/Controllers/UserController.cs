using Microsoft.AspNetCore.Mvc;

using BankClient.Bl.Shared;

namespace BankClient.RestApi.Controllers;

/// <summary>������������. ����������.</summary>
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
    /// �������� ������������ �� ��������������.
    /// </summary>
    /// <param name="id">�������������.</param>
    /// <returns>������������.</returns>
    [HttpGet("{id}")]
    public async Task<UserDto?> GetAsync(long id)
    {   
        return await _service.GetUserByIdAsync(id);
    }
}
