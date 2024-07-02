namespace BankClient.Dal;

/// <summary>Счет пользователя. Репозиторий.</summary>
public interface IUserAccountRepository
{
    /// <summary>
    /// Получить счета пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Список счетов.</returns>
    public Task<ICollection<UserAccountDal>> ListAccountByUserIdAsync(long userId);
}
