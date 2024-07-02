using BankClient.Bl.Shared;
using BankClient.Dal;

namespace BankClient.Bl;

/// <summary>Аутентификация. Сервис.</summary>
public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly IJwtProvider _jwtProvider;

    /// <summary>Исключение при неудачной авторизации.</summary>
    public class LoginFailedException : Exception
    {
        public LoginFailedException() : base("Failed to login")
        {
        }
    }

    public AuthenticationService(
        IUserRepository userReposiroty,
        IPasswordService passwordService,
        IJwtProvider jwtProvider)
    {
        _userRepository = userReposiroty;
        _passwordService = passwordService;
        _jwtProvider = jwtProvider;
    }

    /// <summary>
    /// Авторизация.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Токен.</returns>
    public async Task<string> LoginAsync(string phoneNumber, string password)
    {
        var user = await _userRepository.GetUserByPhoneNumberAsync(phoneNumber) ?? throw new LoginFailedException();
        var verifyResult = _passwordService.VerifyPassword(password, user.Password, user.Salt);

        if (!verifyResult)
            throw new LoginFailedException();

        var token = _jwtProvider.GenerateToken(user.Id, user.PhoneNumber);
        return token;
    }
}
