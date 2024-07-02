using BankClient.Bl.Shared;
using Grpc.Core;

namespace BankClient.Bl.Grpc.Services;

/// <summary>Пользователь. Сервис GRPC.</summary>
public class UserService : User.UserBase
{
    private readonly IUserService _service;
    public UserService(IUserService service)
    {
        _service = service;
    }

    /// <summary>
    /// Получить пользователя по идентификатору.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="context">Контекст.</param>
    /// <returns>Ответ.</returns>
    public override async Task<GetByIdResponse> GetById(GetByIdRequest request, ServerCallContext context)
    {
        var result = new GetByIdResponse();

        var data = await _service.GetUserByIdAsync(request.UserId);

        if (data is null)
            return result;

        result.User = new()
        {
            Id = data.Id,
            Name = data.Name,
            Surname = data.Surname,
            Patronymic = data.Patronymic,
            PhoneNumber = data.PhoneNumber
        };

        return result;
    }
}
