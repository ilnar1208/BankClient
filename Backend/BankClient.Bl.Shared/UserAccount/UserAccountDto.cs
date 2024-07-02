namespace BankClient.Bl.Shared;

/// <summary>Счет пользователя.</summary>
public class UserAccountDto
{
    /// <summary>Идентификатор.</summary>
    public long Id { get; set; }
    /// <summary>Идентификатор пользователя.</summary>
    public long UserId { get; set; }
    /// <summary>Идентификатор типа счета.</summary>
    public long AccountTypeId { get; set; }
    /// <summary>Наименование типа счета.</summary>
    public string AccountTypeName { get; set; } = null!;
    /// <summary>Номер счета.</summary>
    public string AccountNumber { get; set; } = null!;
}
