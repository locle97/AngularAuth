using JwtAuth.Infrastructure.Repository;

namespace JwtAuth.Service;

public interface IAuthService
{
    Task<bool> Auth(string username, string password);
}

public class AuthService : IAuthService
{
    private IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public Task<bool> Auth(string username, string password)
    {
        return _authRepository.CheckValidUser(username, password);
    }
}
