using Microsoft.AspNetCore.Mvc;

using BankClient.Bl.Shared;

namespace BankClient.RestApi.Controllers;

/// <summary>���� ������������. ����������.</summary>
[ApiController]
[Route("user_account")]
public class UserAccountController : ControllerBase
{
    private readonly IUserAccountService _service;

    public UserAccountController(IUserAccountService service)
    {
        _service = service;
    }

    /// <summary>
    /// �������� ����� ������������.
    /// </summary>
    /// <param name="userId">������������� ������������.</param>
    /// <returns>������ ������.</returns>
    [HttpGet("user/{user_id}")]
    public async Task<ICollection<UserAccountDto>> ListAccountByUserIdAsync(
        [FromRoute(Name = "user_id")] long userId)
    {   
        return await _service.ListAccountByUserIdAsync(userId);
    }
}
