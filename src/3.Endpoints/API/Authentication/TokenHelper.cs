using System.Security.Cryptography;

namespace OvetimePolicies1.Endpoints.API.Authentication;

public static class TokenHelper
{
    public static string GenerateRefreshToken()
    {
        var bytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}
