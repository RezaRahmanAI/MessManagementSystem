using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MessManagementSystem.Api.Models.Requests;
using MessManagementSystem.Api.Models.Responses;
using MessManagementSystem.Api.Services;

namespace MessManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly JwtProvider _jwtProvider;

    public AuthController(IUserService userService, JwtProvider jwtProvider)
    {
        _userService = userService;
        _jwtProvider = jwtProvider;
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        if (_userService.EmailExists(request.Email))
        {
            return Conflict(new { message = "A user with that email already exists." });
        }

        var user = _userService.CreateUser(request.Email, request.Password, request.Name);
        var token = _jwtProvider.Create(user);
        return Ok(new AuthResponse(token, user.Email, user.Name));
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _userService.ValidateCredentials(request.Email, request.Password);
        if (user is null)
        {
            return Unauthorized(new { message = "Invalid email or password." });
        }

        var token = _jwtProvider.Create(user);
        return Ok(new AuthResponse(token, user.Email, user.Name));
    }

    [Authorize]
    [HttpGet("me")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    public IActionResult Me()
    {
        var email = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value;
        var name = User.Identity?.Name ?? string.Empty;

        if (string.IsNullOrWhiteSpace(email))
        {
            return Unauthorized();
        }

        return Ok(new AuthResponse(string.Empty, email, name));
    }
}
