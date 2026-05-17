using Microsoft.AspNetCore.Mvc;
using OvetimePolicies1.Core.Contracts.Authentication.Users;
using OvetimePolicies1.Core.Domain.Authentication.Entities;
using OvetimePolicies1.Endpoints.API.DTOs;

namespace OvetimePolicies1.Endpoints.API.Authentication;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _repo;
    private readonly JwtTokenGenerator _jwt;

    public AuthController(IUserRepository repo, JwtTokenGenerator jwt)
    {
        _repo = repo;
        _jwt = jwt;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        var exists = await _repo.GetByUsernameAsync(request.Username);
        if (exists != null)
            return BadRequest("Username already exists");

        PasswordHasher.CreatePasswordHash(request.Password, out var hash, out var salt);

        var user = new User
        {
            Username = request.Username,
            PasswordHash = hash,
            PasswordSalt = salt,
            FullName = request.FullName
        };

        await _repo.AddAsync(user);

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _repo.GetByUsernameAsync(request.Username);
        if (user == null)
            return Unauthorized("Invalid username or password");

        if (!PasswordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            return Unauthorized("Invalid username or password");

        string accessToken = _jwt.Generate(user.Id.ToString(), user.Username);
        string refreshToken = TokenHelper.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpireTime = DateTime.UtcNow.AddDays(7);

        await _repo.UpdateAsync(user);

        return Ok(new
        {
            token = accessToken,
            refreshToken = refreshToken,
            user = new
            {
                user.Id,
                user.Username,
                user.FullName
            }
        });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
    {
        var user = await _repo.GetByRefreshTokenAsync(request.RefreshToken);
        if (user == null || user.RefreshTokenExpireTime < DateTime.UtcNow)
            return Unauthorized("Invalid refresh token");

        string newAccessToken = _jwt.Generate(user.Id.ToString(), user.Username);
        string newRefreshToken = TokenHelper.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpireTime = DateTime.UtcNow.AddDays(7);

        await _repo.UpdateAsync(user);

        return Ok(new
        {
            token = newAccessToken,
            refreshToken = newRefreshToken
        });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] RefreshTokenRequest request)
    {
        var user = await _repo.GetByRefreshTokenAsync(request.RefreshToken);
        if (user == null)
            return Ok("Already logged out");

        user.RefreshToken = null;
        user.RefreshTokenExpireTime = null;

        await _repo.UpdateAsync(user);

        return Ok("Logged out");
    }
}
