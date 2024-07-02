namespace BankClient.Bl.Shared;

/// <summary>Пользователь.</summary>
public class UserDto
{
    /// <summary>Идентификатор.</summary>
    public long Id { get; set; }
    /// <summary>Имя.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Пользователь.</summary>
    public string Surname { get; set; } = null!;
    /// <summary>Отчество.</summary>
    public string? Patronymic { get; set; } = null!;
    /// <summary>Номер телефона.</summary>
    public string PhoneNumber { get; set; } = null!;
}
