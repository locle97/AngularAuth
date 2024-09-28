
namespace JwtAuth.Infrastructure.Repository;

public class AuthRepository : IAuthRepository
{
    private ApplicationDbContext _dbContext;
    public AuthRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> CheckValidUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }
}
