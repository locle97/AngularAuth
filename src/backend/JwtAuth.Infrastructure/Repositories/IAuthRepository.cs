namespace JwtAuth.Infrastructure.Repository;

public interface IAuthRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int id);
    Task<bool> CheckValidUser(string username, string password);
}
