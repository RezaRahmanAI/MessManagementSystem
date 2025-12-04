using MessManagementSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MessManagementSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AuthService>();
        return services;
    }
}
