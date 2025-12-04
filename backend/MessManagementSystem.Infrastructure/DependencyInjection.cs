using MessManagementSystem.Application.Abstractions;
using MessManagementSystem.Infrastructure.Auth;
using MessManagementSystem.Infrastructure.Configuration;
using MessManagementSystem.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

        services.AddSingleton<IJwtProvider, JwtProvider>();
        services.AddSingleton<IUserRepository, InMemoryUserRepository>();

        return services;
    }
}
