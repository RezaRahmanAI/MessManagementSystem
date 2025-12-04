using MessManagementSystem.Domain.Entities;

namespace MessManagementSystem.Application.Abstractions;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
