namespace BankClient.Bl.Infrastructure;

/// <summary>Пароль. Сервис.</summary>
public class PasswordService : IPasswordService
{
    /// <summary>
    /// Верификация пароля.
    /// </summary>
    /// <param name="incomingPassword">Входящий пароль.</param>
    /// <param name="storedPassword">Хранимый пароль.</param>
    /// <param name="storedSalt">Хранимая соль.</param>
    /// <returns>Результат.</returns>
    public bool VerifyPassword(string incomingPassword, string storedPassword, string storedSalt)
    {
        string preparedPassword = string.Concat(storedSalt.AsSpan(0, 25), incomingPassword, storedSalt.AsSpan(25, 25));

        return storedPassword.Equals(HashPassword(preparedPassword));
    }

    /// <summary>
    /// Получить хэш пароля.
    /// </summary>
    /// <param name="password">Пароль.</param>
    /// <returns>Хэш.</returns>
    public string HashPassword(string password)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(password);
        using var hash = System.Security.Cryptography.SHA512.Create();
        var hashedInputBytes = hash.ComputeHash(bytes);

        var hashedInputStringBuilder = new System.Text.StringBuilder(128);
        foreach (var b in hashedInputBytes)
            hashedInputStringBuilder.Append(b.ToString("x2"));
        return hashedInputStringBuilder.ToString();
    }


}
