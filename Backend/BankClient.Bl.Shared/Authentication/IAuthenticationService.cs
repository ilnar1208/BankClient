namespace BankClient.Bl.Shared;

/// <summary>Аутентификация. Сервис.</summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Авторизация.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Токен.</returns>
    public Task<string> LoginAsync(string phoneNumber, string password);
}
