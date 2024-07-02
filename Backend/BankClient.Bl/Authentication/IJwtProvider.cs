namespace BankClient.Bl;

/// <summary>Провайдер JWT.</summary>
public interface IJwtProvider
{
    /// <summary>Сгенерировать токен.</summary>
    public string GenerateToken(long userId, string phoneNumber);
}
