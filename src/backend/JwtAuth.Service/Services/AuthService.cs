using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuth.Domain.Entities;
using JwtAuth.Infrastructure.Repository;
using Microsoft.IdentityModel.Tokens;

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

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(User user)
    {
        // Load key
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("UMvyndtwei5YsSXHQ1Rd1Py93rgJa1gu"));

        // Define credentials
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // build token object
        var payload = new JwtSecurityToken(
            issuer: "my_issuer",
            audience: "your_audience",
            claims: new List<Claim>()
            {
                new Claim("username", user.Username),
                new Claim("role", user.Username),
            },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );

        // Generate
        return new JwtSecurityTokenHandler().WriteToken(payload);
    }
}
