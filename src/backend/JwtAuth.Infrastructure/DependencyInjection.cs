using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JwtAuth.Infrastructure.Repository;

namespace JwtAuth.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite("Data Source=./auth.db");
        });
        services.AddScoped<ApplicationDbContext, ApplicationDbContext>();

        // Add Repositories
        services.AddScoped<IAuthRepository, AuthRepository>();

        return services;
    }
}
