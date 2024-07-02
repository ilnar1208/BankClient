using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BankClient.Dal.Ef;

/// <summary>Пользователь. Репозиторий.</summary>
internal sealed class UserRepository : BaseEntityRepository<User, UserDal>, IUserRepository
{
    public UserRepository(BankClientDataContext dataContext) : base(dataContext)
    {
    }

    /// <summary>
    /// Получить всех пользователей.
    /// </summary>
    /// <returns>Список всех пользователей.</returns>
    public async Task<ICollection<UserDal>> GetAllAsync()
    {
        var data = await DataContext.User.ToListAsync();
        return ProcessResultList(data);
    }

    /// <summary>
    /// Получить пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Пользователь.</returns>
    public async Task<UserDal?> GetUserByIdAsync(long id)
    {
        var user = await DataContext.User.FirstOrDefaultAsync(u => u.Id == id);
        return user?.Adapt<UserDal>();
    }

    /// <summary>
    /// Получить пользователя по номеру телефона.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона</param>
    /// <returns>Пользователь.</returns>
    public async Task<UserDal?> GetUserByPhoneNumberAsync(string phoneNumber)
    {
        var user = await DataContext.User.FirstOrDefaultAsync(u => u.PhoneNumber.Equals(phoneNumber));
        return user?.Adapt<UserDal>();
    }
}
