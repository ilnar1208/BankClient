namespace BankClient.Dal.Ef;

/// <summary>Репозиторий. Базовый.</summary>
internal class BaseRepository
{
    /// <summary>Контекст данных.</summary>
    protected readonly BankClientDataContext DataContext;

    public BaseRepository(BankClientDataContext dataContext)
    {
        DataContext = dataContext;
    }
}
