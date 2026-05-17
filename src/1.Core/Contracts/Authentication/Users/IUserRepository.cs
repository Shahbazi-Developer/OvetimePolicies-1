using OvetimePolicies1.Core.Domain.Authentication.Entities;

namespace OvetimePolicies1.Core.Contracts.Authentication.Users;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByRefreshTokenAsync(string refreshToken);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}
