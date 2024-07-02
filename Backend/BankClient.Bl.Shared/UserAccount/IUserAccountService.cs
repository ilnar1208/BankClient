namespace BankClient.Bl.Shared;

/// <summary>Cчет пользователя. Сервис.</summary>
public interface IUserAccountService
{
    /// <summary>
    /// Получить счета пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Список счетов.</returns>
    public Task<ICollection<UserAccountDto>> ListAccountByUserIdAsync(long userId);
}
