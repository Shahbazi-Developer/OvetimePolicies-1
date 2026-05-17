using System.Security.Cryptography;
using System.Text;

namespace OvetimePolicies1.Endpoints.API.Authentication;

public static class PasswordHasher
{
    public static void CreatePasswordHash(string password, out string hash, out string salt)
    {
        using var hmac = new HMACSHA256();
        salt = Convert.ToBase64String(hmac.Key);
        hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }

    public static bool VerifyPassword(string password, string hash, string salt)
    {
        using var hmac = new HMACSHA256(Convert.FromBase64String(salt));
        var computed = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        return computed == hash;
    }
}
