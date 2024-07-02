using BankClient.Bl.Shared;
using Grpc.Core;

namespace BankClient.Bl.Grpc.Services;

/// <summary>���� ������������. ������ GRPC.</summary>
public class UserAccountService : UserAccount.UserAccountBase
{
    private readonly IUserAccountService _service;
    public UserAccountService(IUserAccountService service)
    {
        _service = service;
    }

    /// <summary>
    /// �������� ����� ������������.
    /// </summary>
    /// <param name="request">������.</param>
    /// <param name="context">��������.</param>
    /// <returns>�����.</returns>
    public override async Task<ListAccountByUserIdResponse> ListAccountByUserId(ListAccountByUserIdRequest request, ServerCallContext context)
    {
        var data = await _service.ListAccountByUserIdAsync(request.UserId);
        var items = from d in data
                    select new UserAccountItem()
                    {
                        Id = d.Id,
                        UserId = d.UserId,
                        AccountNumber = d.AccountNumber,
                        AccountTypeId = d.AccountTypeId,
                        AccountTypeName = d.AccountTypeName
                    };

        var result = new ListAccountByUserIdResponse();
        result.Accounts.AddRange(items);

        return result;
    }
}
