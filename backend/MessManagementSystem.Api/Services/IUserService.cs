using MessManagementSystem.Api.Entities;

namespace MessManagementSystem.Api.Services;

public interface IUserService
{
    User CreateUser(string email, string password, string name);
    User? ValidateCredentials(string email, string password);
    bool EmailExists(string email);
    User? GetByEmail(string email);
}
