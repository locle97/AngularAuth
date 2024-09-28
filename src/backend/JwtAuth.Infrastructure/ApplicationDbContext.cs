using Microsoft.EntityFrameworkCore;

namespace JwtAuth.Infrastructure;

public class ApplicationDbContext : DbContext
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(t => t.Id);
        modelBuilder.Entity<User>().HasData(
            new User() {
                Id = 1,
                Username = "admin",
                Password = "123456"
            },
            new User() {
                Id = 2,
                Username = "user",
                Password = "123456"
            }
        );
    }
}
