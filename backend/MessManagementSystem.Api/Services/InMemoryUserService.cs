using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;
using MessManagementSystem.Api.Entities;

namespace MessManagementSystem.Api.Services;

public class InMemoryUserService : IUserService
{
    private readonly ConcurrentDictionary<string, User> _users = new(StringComparer.OrdinalIgnoreCase);

    public User CreateUser(string email, string password, string name)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();
        var user = new User
        {
            Email = normalizedEmail,
            PasswordHash = HashPassword(password),
            Name = name
        };

        if (!_users.TryAdd(normalizedEmail, user))
        {
            throw new InvalidOperationException("User already exists.");
        }

        return user;
    }

    public bool EmailExists(string email) => _users.ContainsKey(email.Trim().ToLowerInvariant());

    public User? ValidateCredentials(string email, string password)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();

        if (_users.TryGetValue(normalizedEmail, out var user) && user.PasswordHash == HashPassword(password))
        {
            return user;
        }

        return null;
    }

    public User? GetByEmail(string email)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();
        return _users.TryGetValue(normalizedEmail, out var user) ? user : null;
    }

    private static string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }
}
