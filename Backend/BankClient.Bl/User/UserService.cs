using Mapster;

using BankClient.Dal;
using BankClient.Bl.Shared;

namespace BankClient.Bl;

/// <summary>Пользователь. Сервис.</summary>
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userReposiroty)
    {
        _userRepository = userReposiroty;
    }

    /// <summary>
    /// Получить пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Пользователь.</returns>
    public async Task<UserDto?> GetUserByIdAsync(long id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return user is null ? null : user.Adapt<UserDto>();
    }
}
