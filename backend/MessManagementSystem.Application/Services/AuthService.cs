using System.Security.Cryptography;
using System.Text;
using MessManagementSystem.Application.Abstractions;
using MessManagementSystem.Application.Auth;
using MessManagementSystem.Domain.Entities;

namespace MessManagementSystem.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public AuthService(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<AuthResult?> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var existingUser = await _userRepository.GetByEmailAsync(email, cancellationToken);
        if (existingUser is null || existingUser.PasswordHash != HashPassword(password))
        {
            return null;
        }

        var token = _jwtProvider.GenerateToken(existingUser);
        return new AuthResult(existingUser.Email, existingUser.FullName, token);
    }

    public async Task<AuthResult?> RegisterAsync(string email, string fullName, string password, CancellationToken cancellationToken = default)
    {
        var existingUser = await _userRepository.GetByEmailAsync(email, cancellationToken);
        if (existingUser is not null)
        {
            return null;
        }

        var user = new User
        {
            Email = email,
            FullName = fullName,
            PasswordHash = HashPassword(password)
        };

        await _userRepository.AddAsync(user, cancellationToken);

        var token = _jwtProvider.GenerateToken(user);
        return new AuthResult(user.Email, user.FullName, token);
    }

    private static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }
}
