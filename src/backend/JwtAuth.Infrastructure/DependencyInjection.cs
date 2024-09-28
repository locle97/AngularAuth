using Microsoft.EntityFrameworkCore;
using JwtAuth.Infrastructure.Repository;
using JwtAuth.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

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
