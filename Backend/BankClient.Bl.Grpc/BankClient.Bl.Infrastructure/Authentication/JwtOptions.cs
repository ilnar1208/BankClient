namespace BankClient.Bl.Infrastructure;

/// <summary>Настройки JWT.</summary>
public class JwtOptions
{
    /// <summary>Секретный ключ.</summary>
    public string SecretKey { get; set; } = null!;
    /// <summary>Время истечения. Минуты.</summary>
    public int ExpiresMinutes { get; set; }
}
