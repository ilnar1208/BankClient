namespace BankClient.Bl.Shared;

/// <summary>Пользователь. Сервис.</summary>
public interface IUserService
{
    /// <summary>
    /// Получить пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Пользователь.</returns>
    public Task<UserDto?> GetUserByIdAsync(long id);
}
