namespace MessManagementSystem.Api.Contracts.Requests;

public record RegisterRequest(string Email, string FullName, string Password);
