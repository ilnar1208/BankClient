using Microsoft.EntityFrameworkCore;

namespace BankClient.Dal.Ef;

/// <summary>Счет пользователя. Репозиторий.</summary>
internal sealed class UserAccountRepository : BaseEntityRepository<UserAccount, UserAccountDal>, IUserAccountRepository
{
    public UserAccountRepository(BankClientDataContext dataContext) : base(dataContext)
    {
    }

    /// <summary>
    /// Получить счета пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Список счетов.</returns>
    public async Task<ICollection<UserAccountDal>> ListAccountByUserIdAsync(long userId)
    {
        var data = await DataContext.UserAccount
            .Include(a => a.AccountType)
            .Where(d => d.UserId == userId).ToListAsync();
        return ProcessResultList(data);
    }
}
 