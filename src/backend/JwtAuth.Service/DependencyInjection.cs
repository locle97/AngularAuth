using JwtAuth.Service;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependecyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
