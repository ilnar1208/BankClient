namespace BankClient.Bl;

/// <summary>Пароль. Сервис.</summary>
public interface IPasswordService
{
    /// <summary>
    /// Верификация пароля.
    /// </summary>
    /// <param name="incomingPassword">Входящий пароль.</param>
    /// <param name="storedPassword">Хранимый пароль.</param>
    /// <param name="storedSalt">Хранимая соль.</param>
    /// <returns>Результат.</returns>
    public bool VerifyPassword(string incomingPassword, string storedPassword, string storedSalt);

    /// <summary>
    /// Получить хэш пароля.
    /// </summary>
    /// <param name="password">Пароль.</param>
    /// <returns>Хэш.</returns>
    public string HashPassword(string password);
}
