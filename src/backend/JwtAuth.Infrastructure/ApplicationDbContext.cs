using Microsoft.EntityFrameworkCore;

namespace JwtAuth.Infrastructure;

public class ApplicationDbContext: DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    {
    }

    public ApplicationDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite($"Data Source=../auth.db");
    }
}
