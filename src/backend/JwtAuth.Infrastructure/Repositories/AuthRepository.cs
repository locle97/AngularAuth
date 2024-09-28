using Microsoft.EntityFrameworkCore;

namespace JwtAuth.Infrastructure.Repository;

public class AuthRepository : IAuthRepository
{
    private ApplicationDbContext _dbContext;
    public AuthRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> Auth(string username, string password)
    {
        User user = await _dbContext.Users.Where(t => t.Username == username && t.Password == password).FirstOrDefaultAsync();
        return user;
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
