namespace JwtAuth.Infrastructure.Repository;

public interface IAuthRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int id);
    Task<User> Auth(string username, string password);
}
