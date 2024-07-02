namespace BankClient.Dal;

/// <summary>Пользователь.</summary>
public class UserDal
{
    /// <summary>Идентификатор.</summary>
    public long Id { get; set; }
    /// <summary>Имя.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Фамилия.</summary>
    public string Surname { get; set; } = null!;
    /// <summary>Отчество.</summary>
    public string? Patronymic { get; set; } = null!;
    /// <summary>Номер телефона.</summary>
    public string PhoneNumber { get; set; } = null!;
    /// <summary>Пароль.</summary>
    public string Password { get; set; } = null!;
    /// <summary>Соль.</summary>
    public string Salt { get; set; } = null!;
}
