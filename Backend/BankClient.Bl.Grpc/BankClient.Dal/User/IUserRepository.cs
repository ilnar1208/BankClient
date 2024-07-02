namespace BankClient.Dal;

/// <summary>Пользователь. Репозиторий.</summary>
public interface IUserRepository
{
    /// <summary>
    /// Получить пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Пользователь.</returns>
    public Task<UserDal?> GetUserByIdAsync(long id);

    /// <summary>
    /// Получить пользователя по номеру телефона.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона</param>
    /// <returns>Пользователь.</returns>
    public Task<UserDal?> GetUserByPhoneNumberAsync(string phoneNumber);

    /// <summary>
    /// Получить всех пользователей.
    /// </summary>
    /// <returns>Список всех пользователей.</returns>
    public Task<ICollection<UserDal>> GetAllAsync();
}
