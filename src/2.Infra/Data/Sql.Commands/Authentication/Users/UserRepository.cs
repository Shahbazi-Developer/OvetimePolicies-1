using Microsoft.EntityFrameworkCore;
using OvetimePolicies1.Core.Contracts.Authentication.Users;
using OvetimePolicies1.Core.Domain.Authentication.Entities;
using OvetimePolicies1.Infra.Data.Sql.Commands.Common;

namespace OvetimePolicies1.Infra.Data.Sql.Commands.Authentication.Users;

public class UserRepository : IUserRepository
{
    private readonly OvetimePolicies1CommandDbContext _ctx;

    public UserRepository(OvetimePolicies1CommandDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _ctx.Users.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _ctx.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
    }

    public async Task AddAsync(User user)
    {
        _ctx.Users.Add(user);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _ctx.Users.Update(user);
        await _ctx.SaveChangesAsync();
    }
}
