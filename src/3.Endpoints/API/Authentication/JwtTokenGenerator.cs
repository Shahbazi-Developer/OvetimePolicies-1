using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OvetimePolicies1.Endpoints.API.Authentication;

public class JwtTokenGenerator
{
    private readonly JwtOptions _opt;
    private readonly SymmetricSecurityKey _signingKey;

    public JwtTokenGenerator(IOptions<JwtOptions> options)
    {
        _opt = options.Value;

        if (string.IsNullOrWhiteSpace(_opt.Key))
            throw new Exception("JWT Key is missing in configuration");

        if (_opt.Key.Length < 32)
            throw new Exception("JWT Key must be at least 32 characters for HS256");

        _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_opt.Key));
    }

    /// <summary>
    /// Generates HS256 JWT Token
    /// </summary>
    public string Generate(string userId = "system", string username = "system-service")
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.UniqueName, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var creds = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _opt.Issuer,
            audience: _opt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_opt.ExpirationMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
