using Mapster;

namespace BankClient.Dal.Ef;

/// <summary>
/// Репозиторий. Сущность. Базовый.
/// </summary>
/// <typeparam name="TDbItem">Тип сущности Db.</typeparam>
/// <typeparam name="TDalItem">Тип сущности Dal.</typeparam>
internal class BaseEntityRepository<TDbItem, TDalItem> : BaseRepository
{
    private static readonly List<TDalItem> EmptyEntityList = new (0);

    public BaseEntityRepository(BankClientDataContext dataContext) : base(dataContext)
    {
    }

    /// <summary>
    /// Обработать список сущностей.
    /// </summary>
    /// <param name="sourceData">Список сущностей Db.</param>
    /// <returns>Список сущностей Dal.</returns>
    protected static List<TDalItem> ProcessResultList(List<TDbItem> sourceData)
    {
        if ((sourceData?.Count ?? 0) == 0)
            return EmptyEntityList;
    
        var result = sourceData.Adapt<List<TDalItem>>();
    
        if ((result?.Count ?? 0) == 0)
            return EmptyEntityList;
    
        return result!;
    }
}
