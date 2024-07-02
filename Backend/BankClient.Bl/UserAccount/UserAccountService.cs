using Mapster;

using BankClient.Dal;
using BankClient.Bl.Shared;

namespace BankClient.Bl;

/// <summary>Cчет пользователя. Сервис.</summary>
public class UserAccountService : IUserAccountService
{
    private readonly IUserAccountRepository _userAccountRepository;

    public UserAccountService(IUserAccountRepository userAccountReposiroty)
    {
        _userAccountRepository = userAccountReposiroty;
    }

    /// <summary>
    /// Получить счета пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Список счетов.</returns>
    public async Task<ICollection<UserAccountDto>> ListAccountByUserIdAsync(long userId)
    {
        var data = await _userAccountRepository.ListAccountByUserIdAsync(userId);

        return data.Adapt<List<UserAccountDto>>();
    }
}
