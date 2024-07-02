using BankClient.Bl.Shared;

namespace BankClient.Bl.Grpc.Client;

/// <summary>Пользователь. Сервис</summary>
public class UserService : IUserService
{
    private readonly User.UserClient _client;

    public UserService(User.UserClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Получить пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Пользователь.</returns>
    public async Task<UserDto?> GetUserByIdAsync(long id)
    {
        var reply = await _client.GetByIdAsync(new GetByIdRequest { UserId = id });

        return reply.User is null ? null : new UserDto()
        {
            Id = reply.User.Id,
            Name = reply.User.Name,
            Surname = reply.User.Surname,
            Patronymic = reply.User.Patronymic,
            PhoneNumber = reply.User.PhoneNumber
        };
    }
}
