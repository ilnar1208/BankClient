namespace BankClient.Dal.Ef;

/// <summary>Счет пользователя.</summary>
public class UserAccount
{
    /// <summary>Идентификатор.</summary>
    public long Id { get; set; }
    /// <summary>Идентификатор пользователя.</summary>
    public long UserId { get; set; }
    /// <summary>Тип счета.</summary>
    public AccountType AccountType { get; set; } = null!;
    /// <summary>Номер счета.</summary>
    public string AccountNumber { get; set; } = null!;
}

/// <summary>Тип счета.</summary>
public class AccountType
{
    /// <summary>Идентификатор.</summary>
    public long Id { get; set; }
    /// <summary>Наименование.</summary>
    public string Name { get; set; } = null!;
}
