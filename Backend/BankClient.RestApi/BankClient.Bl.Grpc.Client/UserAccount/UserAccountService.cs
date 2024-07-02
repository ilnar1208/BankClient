using BankClient.Bl.Shared;

namespace BankClient.Bl.Grpc.Client;

/// <summary>Cчет пользователя. Сервис.</summary>
public class UserAccountService : IUserAccountService
{
    private readonly UserAccount.UserAccountClient _client;

    public UserAccountService(UserAccount.UserAccountClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Получить счета пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Список счетов.</returns>
    public async Task<ICollection<UserAccountDto>> ListAccountByUserIdAsync(long userId)
    {
        var reply = await _client.ListAccountByUserIdAsync(new ListAccountByUserIdRequest { UserId = userId });

        return reply.Accounts.Select(d => new UserAccountDto()
        {
            Id = d.Id,
            UserId = d.Id,
            AccountNumber = d.AccountNumber,
            AccountTypeId = d.AccountTypeId,
            AccountTypeName = d.AccountTypeName
        }).ToArray();
    }
}
