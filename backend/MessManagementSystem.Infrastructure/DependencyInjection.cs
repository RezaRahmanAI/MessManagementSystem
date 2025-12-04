using System;
using MessManagementSystem.Application.Abstractions;
using MessManagementSystem.Infrastructure.Auth;
using MessManagementSystem.Infrastructure.Configuration;
using MessManagementSystem.Infrastructure.Persistence;
using MessManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddSingleton<IJwtProvider, JwtProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
