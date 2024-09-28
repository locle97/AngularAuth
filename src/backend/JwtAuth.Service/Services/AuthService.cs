using JwtAuth.Domain.Entities;
using JwtAuth.Infrastructure.Repository;

namespace JwtAuth.Service;

public interface IAuthService
{
    // Check if valid user or not Return token
    Task<string> Auth(string username, string password);
}

public class AuthService : IAuthService
{
    private IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<string> Auth(string username, string password)
    {
        User user = await _authRepository.Auth(username, password);
        if (user is null)
            throw new UnauthorizedAccessException();

        return "Valid";
    }
}
